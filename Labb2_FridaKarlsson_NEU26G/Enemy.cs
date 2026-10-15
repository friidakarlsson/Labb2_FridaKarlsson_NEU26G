

namespace Labb2_FridaKarlsson_NEU26G
{
    internal abstract class Enemy : MovingElements
    {

        public Enemy(int x, int y, char character, ConsoleColor color, string name, int hp, Dice attack, Dice defence) : base(x, y, character, color, name, hp, attack, defence) 
        { 

        }

        public abstract void Update(LevelData leveldata);
    }
}
