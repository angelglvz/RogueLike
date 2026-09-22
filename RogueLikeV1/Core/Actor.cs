using RLNET;
using RogueSharp;
using RogueLikeV1.interfaces;

namespace RogueLikeV1.Core
{
    public class Actor: IActor, IDrawable
    {
        public string Name { get; set; }
        public int Awareness { get; set; }
        
        public RLColor Colour { get; set; }
        public char Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        
        public void Draw (RLConsole console, IMap map)
        {
           if(!map.GetCell(X, Y).IsExplored)
           {
                return;
           }
            if (map.IsInFov(X, Y))
            {
                console.Set(X, Y, Colour, Colours.FloorBackgroundFov, Symbol);
            }
            else
            {
                console.Set(X, Y, Colours.Floor, Colours.FloorBackground, '.');
            }
        }
    }
}
