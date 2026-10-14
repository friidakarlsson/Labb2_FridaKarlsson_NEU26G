

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Player : MovingElements
    {
        public Player(int x, int y, string playerName) : base(x, y, '@', ConsoleColor.Yellow, playerName, 100, new Dice(2, 6, 2), new Dice(2, 6, 0))
        {

        }
    }
}
