using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Player :LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        public Player(int x, int y) :base(x, y)
        {
            Name = "Player";
            Health = 100;
            color = ConsoleColor.Yellow;
            character = '@';
            AttackDice = new Dice(2, 6, 2);
            DefenceDice = new Dice(2, 6, 0);
        }
    }
}
