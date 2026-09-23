using OpenTK.Graphics;
using RLNET;

namespace RogueLikeV1.Core
{
    public class Player: Actor
    {
        public Player()
        {
            Attack = 2;
            AttackChance = 50;
            Awareness = 15;
            Colour = Colours.Player;
            Defense = 2;
            DefenseChance = 40;
            Gold = 0;
            Health = 100;
            MaxHealth = 100;
            Name = "Rogue";
            Speed = 10;
            Symbol = '@';
        }

        public void DrawStats(RLConsole statConsole)
        {
            statConsole.Print(1, 1, $"Name:    {Name}", Colours.Text);
            statConsole.Print(1, 3, $"Health:  {Health}/{MaxHealth}", Colours.Text);
            statConsole.Print(1, 5, $"Attack:  {Attack} ({AttackChance}%)", Colours.Text);
            statConsole.Print(1, 7, $"Defense: {Defense} ({DefenseChance}%)", Colours.Text);
            statConsole.Print(1, 9, $"Gold:    {Gold}", Colours.Gold);
        }
    }
}
