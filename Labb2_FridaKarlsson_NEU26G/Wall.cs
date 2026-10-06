using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Wall : LevelElement
    {
        public Wall(int x, int y) : base(x, y)
        {
            character = '#'; 
            color = ConsoleColor.Gray;
        }
    }
}
