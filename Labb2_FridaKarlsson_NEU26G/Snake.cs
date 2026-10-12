

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

        public override void Update(LevelData leveldata)
        {

            int enemyNextMoveX = xPosition;
            int enemyNextMoveY = yPosition;

            double snakeDistance = Math.Sqrt(Math.Pow(xPosition - leveldata.PlayerCurrentPosition.xPosition, 2) + Math.Pow(yPosition - leveldata.PlayerCurrentPosition.yPosition, 2));

            if (snakeDistance > 2) return;

            if (enemyNextMoveX < leveldata.PlayerCurrentPosition.xPosition)
            {
                enemyNextMoveX--;
            }
            else if (enemyNextMoveX > leveldata.PlayerCurrentPosition.xPosition)
            {
                enemyNextMoveX++;
            }
            else if (enemyNextMoveY < leveldata.PlayerCurrentPosition.yPosition)
            {
                enemyNextMoveY--;
            }
            else if (enemyNextMoveY > leveldata.PlayerCurrentPosition.yPosition)
            {
                enemyNextMoveY++;
            }

            if (MakeAMove(enemyNextMoveX, enemyNextMoveY, leveldata))
            {
                xPosition = enemyNextMoveX;
                yPosition = enemyNextMoveY;
            }
            else
            {
                if (enemyNextMoveX == leveldata.PlayerCurrentPosition.xPosition && enemyNextMoveY == leveldata.PlayerCurrentPosition.yPosition)
                {
                    Attack(leveldata.PlayerCurrentPosition);
                }
            }
        }
    }
}
