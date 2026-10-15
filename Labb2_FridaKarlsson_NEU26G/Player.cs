

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Player : MovingElements
    {
        public Player(int x, int y, string playerName) : base(x, y, '@', ConsoleColor.Yellow, playerName, 100, new Dice(2, 6, 2), new Dice(2, 6, 0))
        {

        }

        public string PlayerUpdate(ConsoleKeyInfo pressedKey, LevelData levelData)
        {
            int playerNextMoveX = xPosition;
            int playerNextMoveY = yPosition;


            switch (pressedKey.Key)
            {
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    playerNextMoveX++; break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    playerNextMoveX--; break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    playerNextMoveY++; break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    playerNextMoveY--; break;
                default: break;
            }

            if (MakeAMove(playerNextMoveX, playerNextMoveY, levelData))
            {
                xPosition = playerNextMoveX;
                yPosition = playerNextMoveY;

                levelData.PlayerPosition = this;
            }
            else
            {
                foreach (LevelElement element in levelData.Elements)
                {
                    if (element is Enemy && playerNextMoveX == element.xPosition && playerNextMoveY == element.yPosition)
                    {
                        Attack((Enemy)element);
                        ((Enemy)element).WasInAFight = true;

                        return Attack((Enemy)element);
                    }
                }
            }
            
            return string.Empty;
        }

    }
}
