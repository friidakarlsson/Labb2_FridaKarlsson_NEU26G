
using System.Collections;
using System.Drawing;
using System.Xml.Linq;

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Rat : Enemy
    {
        public Rat(int x, int y) : base( x, y, 'r', ConsoleColor.Red, "Rat", 10, new Dice(1, 6, 3), new Dice(1, 6, 1))
        {

        }

        public override string Update(LevelData leveldata)
        {
            int enemyNextMoveX = xPosition;
            int enemyNextMoveY = yPosition;

            Random random = new Random();
            int randomMoveNumber = random.Next(1, 5);

            switch (randomMoveNumber)
            {
                case 1: enemyNextMoveX++; break;
                case 2: enemyNextMoveX--; break;
                case 3: enemyNextMoveY++; break;
                case 4: enemyNextMoveY--; break;
            }

            if (MakeAMove(enemyNextMoveX, enemyNextMoveY, leveldata))
            {
                xPosition = enemyNextMoveX;
                yPosition = enemyNextMoveY;               
            }
            else
            {
                if (enemyNextMoveX == leveldata.PlayerPosition.xPosition && enemyNextMoveY == leveldata.PlayerPosition.yPosition)
                {
                    string attackText = Attack(leveldata.PlayerPosition);
                    return attackText;
                }            
            }

            return string.Empty;
        }
    }
}
