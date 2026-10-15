

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Snake : Enemy
    {
        public Snake(int x, int y) : base(x, y, 's', ConsoleColor.Green, "Snake", 25, new Dice(3, 4, 2), new Dice(1, 8, 5))
        {

        }

        public override void Update(LevelData leveldata)
        {
            double snakeDistance = Math.Sqrt(Math.Pow(xPosition - leveldata.PlayerPosition.xPosition, 2) + Math.Pow(yPosition - leveldata.PlayerPosition.yPosition, 2));

            if (snakeDistance > 2)
            {
                return;
            }

             int nextMoveX = xPosition + (xPosition < leveldata.PlayerPosition.xPosition ? -1 : (xPosition > leveldata.PlayerPosition.xPosition ? +1 : 0));
             int nextMoveY = yPosition + (yPosition < leveldata.PlayerPosition.yPosition ? -1 : (yPosition > leveldata.PlayerPosition.yPosition ? +1 : 0));


            if (MakeAMove(nextMoveX, nextMoveY, leveldata))
            {
                xPosition = nextMoveX;
                yPosition = nextMoveY;
            }            
        }
    }
}
