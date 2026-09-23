using OpenTK.Graphics;
using RLNET;
using RogueLikeV1.interfaces;
using RogueSharp;

namespace RogueLikeV1.Core
{
    public class Door : IDrawable
    {
        public Door()
        {
            Symbol = '+';
            Colour = Colours.Door;
            BackgroundColour = Colours.DoorBackground;
        }
        public bool IsOpen { get; set; }

        public RLColor Colour { get; set; }
        public RLColor BackgroundColour { get; set; }
        public char Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw(RLConsole console, IMap map)
        {
            if (!map.GetCell(X, Y).IsExplored)
            {
                return;
            }

            Symbol = IsOpen ? '-' : '+';
            if (map.IsInFov(X, Y))
            {
                Colour = Colours.DoorFov;
                BackgroundColour = Colours.DoorBackgroundFov;
            }
            else
            {
                Colour = Colours.Door;
                BackgroundColour = Colours.DoorBackground;
            }

            console.Set(X, Y, Colour, BackgroundColour, Symbol);
        }
    }
}
