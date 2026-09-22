using RLNET;
using RogueLikeV1.Core;
using RogueLikeV1.Systems;
using System;

namespace RogueLikeV1
{
    public class Game
    {
        //main screen width and height
        private static readonly int _screenWidth = 100;
        private static readonly int _screenHeight = 70;

        private static RLRootConsole _rootConsole;

        //the map, main part of the screen
        private static readonly int _mapWidth = 80;
        private static readonly int _mapHeight = 48;

        private static RLConsole _mapConsole;

        //the message console, will display attacks and other information
        private static readonly int _messageWidth = 80;
        private static readonly int _messageHeight = 11;

        private static RLConsole _messageConsole;

        //the stat console, will display player and monster stats
        private static readonly int _statWidth = 20;
        private static readonly int _statHeight = 70;

        private static RLConsole _statConsole;

        //the inventory console, will display player inventory
        private static readonly int _inventoryWidth = 80;
        private static readonly int _inventoryHeight = 11;

        private static RLConsole _inventoryConsole;

        public static DungeonMap DungeonMap { get; private set; }

        public static Player Player { get; private set; }

        public static void Main()
        {

            //instanciate and initalize the consoles
            _mapConsole = new RLConsole(_mapWidth, _mapHeight);
            _messageConsole = new RLConsole(_messageWidth, _messageHeight);
            _statConsole = new RLConsole(_statWidth, _statHeight);
            _inventoryConsole = new RLConsole(_inventoryWidth, _inventoryHeight);

            string fontFileName = @"Elementos\terminal8x8.png";
            string consoleTitle = "RogueLike V1 - Level 1";
            _rootConsole = new RLRootConsole(fontFileName, _screenWidth, _screenHeight, 8, 8, 1f, consoleTitle);

            Player = new Player();

            MapGenerator mapGenerator = new MapGenerator(_mapWidth, _mapHeight);
            DungeonMap = mapGenerator.CreateMap();

            DungeonMap.UpdatePlayerFieldOfView();
            _rootConsole.Update += OnRootConsoleUpdate;
            _rootConsole.Render += OnRootConsoleRender;
            _rootConsole.Run();
        }

        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
        {
            //now using assigned colours from the Colours class to set the background and text colours for each console
            _mapConsole.SetBackColor(0, 0, _mapWidth, _mapHeight, Colours.FloorBackground);
            _mapConsole.Print(1, 1, "Map", Colours.TextHeading);

            _messageConsole.SetBackColor(0, 0, _messageWidth, _messageHeight, Swatch.DbDeepWater);
            _messageConsole.Print(1, 1, "Messages", Colours.TextHeading);

            _statConsole.SetBackColor(0, 0, _statWidth, _statHeight, Swatch.DbOldStone);
            _statConsole.Print(1, 1, "Stats", Colours.TextHeading);

            _inventoryConsole.SetBackColor(0, 0, _inventoryWidth, _inventoryHeight, Swatch.DbWood);
            _inventoryConsole.Print(1, 1, "Inventory", Colours.TextHeading);
        }

        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            RLConsole.Blit(_mapConsole, 0, 0, _mapWidth, _mapHeight, _rootConsole, 0, _inventoryHeight);
            RLConsole.Blit(_statConsole, 0, 0, _statWidth, _statHeight, _rootConsole, _mapWidth, 0);
            RLConsole.Blit(_messageConsole, 0, 0, _messageWidth, _messageHeight, _rootConsole, 0, _screenHeight - _messageHeight);
            RLConsole.Blit(_inventoryConsole, 0, 0, _inventoryWidth, _inventoryHeight, _rootConsole, 0, 0);
            _rootConsole.Draw();
            DungeonMap.Draw(_mapConsole);
            Player.Draw(_mapConsole, DungeonMap);
        }
    }
}