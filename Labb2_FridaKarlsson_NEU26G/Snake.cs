using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Snake : Enemy
    {
        public Snake(int x, int y) : base(x, y)
        {
            Name = "Snake";
            Health = 25;
            color = ConsoleColor.Green;
            character = 's';
            AttackDice = new Dice(3, 4, 2);
            DefenceDice = new Dice(1, 8, 5);
        }

        public override void UpDate()
        {

        }
    }
}
