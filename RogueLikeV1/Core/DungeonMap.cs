using RLNET;
using RogueSharp;

namespace RogueLikeV1.Core
{
    public class DungeonMap: Map
    {

        public void Draw(RLConsole mapConsole)
        {
            mapConsole.Clear();
            foreach (Cell cell in GetAllCells())
            {
                SetConsoleSymbolForCell(mapConsole, cell);
            }
        }

        private void SetConsoleSymbolForCell( RLConsole console, Cell cell)
        {
            if (!cell.IsExplored)
            {
                return;
            }

            if (IsInFov( cell.X, cell.Y))
            {
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colours.FloorFov, Colours.FloorBackgroundFov, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colours.WallFov, Colours.WallBackgroundFov, '#');
                }
            }
            else
            {
                if( cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colours.Floor, Colours.FloorBackground, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colours.Wall, Colours.WallBackground, '#');
                }
            }
        }
    }
}
