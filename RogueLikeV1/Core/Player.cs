namespace RogueLikeV1.Core
{
    public class Player: Actor
    {
        public Player()
        {
            Awareness = 15;
            Name = "Rogue";
            Colour = Colours.Player;
            Symbol = '@';
            X = 10;
            Y = 10;
        }
    }
}
