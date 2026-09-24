using OpenTK.Graphics;
using RLNET;
using RogueLikeV1.interfaces;
using RogueSharp;

namespace RogueLikeV1.Core
{
    public class Stairs : IDrawable
    {
        public RLColor Colour
        {
            get; set;
        }
        public char Symbol
        {
            get; set;
        }
        public int X
        {
            get; set;
        }
        public int Y
        {
            get; set;
        }
        public bool IsUp
        {
            get; set;
        }

        public void Draw(RLConsole console, IMap map)
        {
            if (!map.GetCell(X, Y).IsExplored)
            {
                return;
            }

            Symbol = IsUp ? '<' : '>';

            if (map.IsInFov(X, Y))
            {
                Colour = Colours.Player;
            }
            else
            {
                Colour = Colours.Floor;
            }

            console.Set(X, Y, Colour, null, Symbol);
        }
    }
}
