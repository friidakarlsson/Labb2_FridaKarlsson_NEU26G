using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_FridaKarlsson_NEU26G
{
    internal abstract class Enemy : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        public Enemy(int x, int y) :base(x, y) { }

        public abstract void Update(LevelData leveldata);
    }
}
