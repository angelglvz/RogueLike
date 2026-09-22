using RLNET;
using RogueLikeV1.Core;
using RogueLikeV1.Systems;
using RogueSharp.Random;
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
        private static bool _renderRequired = true;

        public static DungeonMap DungeonMap { get; private set; }

        public static Player Player { get; set; }

        public static CommandSystem CommandSystem { get; private set; }

        public static IRandom Random { get; private set; }

        public static void Main()
        {

            string fontFileName = @"Elementos\terminal8x8.png";
            string consoleTitle = "RogueLike V1 - Level 1";

            //instanciate and initalize the consoles
            _mapConsole = new RLConsole(_mapWidth, _mapHeight);
            _messageConsole = new RLConsole(_messageWidth, _messageHeight);
            _statConsole = new RLConsole(_statWidth, _statHeight);
            _inventoryConsole = new RLConsole(_inventoryWidth, _inventoryHeight);

            
            _rootConsole = new RLRootConsole(fontFileName, _screenWidth, _screenHeight, 8, 8, 1f, consoleTitle);

            int seed = (int)DateTime.UtcNow.Ticks;
            Random = new DotNetRandom(seed);

            MapGenerator mapGenerator = new MapGenerator(_mapWidth, _mapHeight, 20, 13, 7);
            DungeonMap = mapGenerator.CreateMap();

            DungeonMap.UpdatePlayerFieldOfView();

            CommandSystem = new CommandSystem();

            _rootConsole.Update += OnRootConsoleUpdate;
            _rootConsole.Render += OnRootConsoleRender;

            _messageConsole.SetBackColor(0, 0, _messageWidth, _messageHeight, Swatch.DbDeepWater);
            _messageConsole.Print(1, 1, "Messages", Colours.TextHeading);

            _statConsole.SetBackColor(0, 0, _statWidth, _statHeight, Swatch.DbOldStone);
            _statConsole.Print(1, 1, "Stats", Colours.TextHeading);

            _inventoryConsole.SetBackColor(0, 0, _inventoryWidth, _inventoryHeight, Swatch.DbWood);
            _inventoryConsole.Print(1, 1, "Inventory", Colours.TextHeading);

            _rootConsole.Run();
        }

        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
        {
            bool didPlayerAct = false;
            RLKeyPress keyPress = _rootConsole.Keyboard.GetKeyPress();

            if (keyPress != null)
            {
                if (keyPress.Key == RLKey.Up)
                {
                    didPlayerAct = CommandSystem.MovePlayer(Direction.Up);
                }
                else if (keyPress.Key == RLKey.Down)
                {
                    didPlayerAct = CommandSystem.MovePlayer(Direction.Down);
                }
                else if (keyPress.Key == RLKey.Left)
                {
                    didPlayerAct = CommandSystem.MovePlayer(Direction.Left);
                }
                else if (keyPress.Key == RLKey.Right)
                {
                    didPlayerAct = CommandSystem.MovePlayer(Direction.Right);
                }
                else if (keyPress.Key == RLKey.Escape)
                {
                    _rootConsole.Close();
                }
            }

            if (didPlayerAct)
            {
                _renderRequired = true;
            }
        }

        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            //redraw everything only if required
            if (_renderRequired)
            {
                //first draw everything so it updates correctly
                DungeonMap.Draw(_mapConsole);
                Player.Draw(_mapConsole, DungeonMap);

                RLConsole.Blit(_mapConsole, 0, 0, _mapWidth, _mapHeight, _rootConsole, 0, _inventoryHeight);
                RLConsole.Blit(_statConsole, 0, 0, _statWidth, _statHeight, _rootConsole, _mapWidth, 0);
                RLConsole.Blit(_messageConsole, 0, 0, _messageWidth, _messageHeight, _rootConsole, 0, _screenHeight - _messageHeight);
                RLConsole.Blit(_inventoryConsole, 0, 0, _inventoryWidth, _inventoryHeight, _rootConsole, 0, 0);
                
                
                _rootConsole.Draw();
                _renderRequired = false;
            }
            
        }
    }
}