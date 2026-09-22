using RLNET;
using RogueSharp;

namespace RogueLikeV1.interfaces
{
    public interface IDrawable
    {
        RLColor Colour { get; set; }
        char Symbol { get; set; }
        int X { get; set; }
        int Y { get; set; }

        void Draw(RLConsole console, IMap map);
    }
}
