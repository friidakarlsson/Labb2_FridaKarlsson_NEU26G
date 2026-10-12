
namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Rat : Enemy
    {
        public Rat(int x, int y) : base(x, y)
        {
            Name = "Rat";
            Health = 10;
            color = ConsoleColor.Red;
            character = 'r';
            AttackDice = new Dice(1, 6, 3);
            DefenceDice = new Dice(1, 6, 1);
        }

        public override void Update(LevelData leveldata)
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
                if (enemyNextMoveX == leveldata.PlayerCurrentPosition.xPosition && enemyNextMoveY == leveldata.PlayerCurrentPosition.yPosition)
                {
                    Attack(leveldata.PlayerCurrentPosition);
                }
            }
        }
    }
}
