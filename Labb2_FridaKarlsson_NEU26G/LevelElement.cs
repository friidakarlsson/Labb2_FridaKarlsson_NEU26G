using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Labb2_FridaKarlsson_NEU26G
{
    internal abstract class LevelElement
    {
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public char character { get; set; }
        public ConsoleColor color { get; set; }

        public LevelElement(int x, int y)
        {
            xPosition = x;
            yPosition = y;
        }
        public void Draw()
        {
            Console.SetCursorPosition(xPosition, yPosition); Console.ForegroundColor = color; Console.Write(character); Console.ResetColor();
        }
    }

}