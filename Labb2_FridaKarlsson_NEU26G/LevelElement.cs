
namespace Labb2_FridaKarlsson_NEU26G
{
    internal abstract class LevelElement
    {

        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public char character { get; set; }
        public ConsoleColor color { get; set; }
        public bool DiscoveredWall { get; set; }

        public LevelElement(int x, int y, char character, ConsoleColor color)
        {
            xPosition = x;
            yPosition = y;
            this.character = character;
            this.color = color;
        }
        public void Draw()
        {
            Console.SetCursorPosition(xPosition, yPosition + 4); Console.ForegroundColor = color; Console.Write(character); Console.ResetColor();
        }

        public bool MakeAMove(int nextMoveX, int nextMoveY, LevelData leveldata)
        {
            foreach (LevelElement element in leveldata.Elements)
            {
                if (element.xPosition == nextMoveX && element.yPosition == nextMoveY)
                {
                    if (element is Wall) return false;
                    if (element is Enemy) return false;
                }
            }

            if (this is Enemy && nextMoveX == leveldata.PlayerPosition.xPosition && nextMoveY == leveldata.PlayerPosition.yPosition)
            {
                return false;
            }

            return true;
        }

    }

}