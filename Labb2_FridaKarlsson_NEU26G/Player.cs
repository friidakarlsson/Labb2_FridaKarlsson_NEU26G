

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class Player : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        public Player(int x, int y) : base(x, y)
        {
            Name = string.Empty;
            Health = 100;
            color = ConsoleColor.Yellow;
            character = '@';
            AttackDice = new Dice(2, 6, 2);
            DefenceDice = new Dice(2, 6, 0);
        }

        public void Attack(Enemy enemy)
        {
            int playerAttack = AttackDice.Throw();
            int enemyAttack = enemy.DefenceDice.Throw();
            int damage = playerAttack - enemyAttack;

            if (damage > 0) { enemy.Health -= damage; }

            if (enemy.Health > 0)
            {
                enemyAttack = enemy.AttackDice.Throw();
                playerAttack = DefenceDice.Throw();
                damage = enemyAttack - playerAttack;

                if (damage > 0) { Health -= damage; }
            }
        }
    }
}
