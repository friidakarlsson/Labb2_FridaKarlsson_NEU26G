using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Rat : Enemy
    {
        public Rat(int x, int y) :base(x, y)
        {
            Name = "Rat";
            Health = 10;
            color = ConsoleColor.Red;
            character = 'r';
            AttackDice = new Dice(1, 6, 3);
            DefenceDice = new Dice(1, 6, 1);
        }

        public override void UpDate()
        {
            
        }
    }
}
