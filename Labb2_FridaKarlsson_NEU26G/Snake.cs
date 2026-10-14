

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Snake : Enemy
    {
        public Snake(int x, int y) : base(x, y, 's', ConsoleColor.Green, "Snake", 25, new Dice(3, 4, 2), new Dice(1, 8, 5))
        {

        }

        public override string Update(LevelData leveldata)
        {

            int nextMoveX = xPosition;
            int nextMoveY = yPosition;

            double snakeDistance = Math.Sqrt(Math.Pow(xPosition - leveldata.PlayerPosition.xPosition, 2) + Math.Pow(yPosition - leveldata.PlayerPosition.yPosition, 2));

            if (snakeDistance > 2) return string.Empty;

            if (nextMoveX < leveldata.PlayerPosition.xPosition)
            {
                nextMoveX--;
            }
            else if (nextMoveX > leveldata.PlayerPosition.xPosition)
            {
                nextMoveX++;
            }

            if (nextMoveY < leveldata.PlayerPosition.yPosition)
            {
                nextMoveY--;
            }
            else if (nextMoveY > leveldata.PlayerPosition.yPosition)
            {
                nextMoveY++;
            }

            if (MakeAMove(nextMoveX, nextMoveY, leveldata))
            {
                xPosition = nextMoveX;
                yPosition = nextMoveY;
            }
            else if (MakeAMove(xPosition, nextMoveY, leveldata))
            {
                yPosition = nextMoveY;
                nextMoveX = xPosition;
            }
            else if (MakeAMove(nextMoveX, yPosition, leveldata))
            {
                xPosition = nextMoveX;
                nextMoveY = yPosition;
            }
            else if (MakeAMove(xPosition + 1, yPosition,leveldata))
            {
                xPosition = xPosition + 1;
            }
            else if (MakeAMove(xPosition, yPosition + 1, leveldata))
            {
                yPosition = yPosition + 1;
            }
            else if (MakeAMove(xPosition - 1, yPosition, leveldata))
            {
                xPosition = xPosition - 1;
            }
            else if (MakeAMove(xPosition, yPosition - 1, leveldata))
            {
                yPosition = yPosition - 1;
            }

            if (nextMoveX == leveldata.PlayerPosition.xPosition && nextMoveY == leveldata.PlayerPosition.yPosition)
            {
                Attack(leveldata.PlayerPosition);
            }

        }
    }
}
