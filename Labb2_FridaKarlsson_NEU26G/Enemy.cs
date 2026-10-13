

namespace Labb2_FridaKarlsson_NEU26G
{
    internal abstract class Enemy : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }
        public bool WasInAFight { get; set; }

        public Enemy(int x, int y) : base(x, y) { }

        public abstract void Update(LevelData leveldata);

            public void Attack(Player player)
        {
            int enemyAttack = AttackDice.Throw();
            int playerAttack = player.DefenceDice.Throw();
            int damage =  enemyAttack - playerAttack;

            if (damage > 0) 
            { 
                player.Health -= damage;
            }

            if (player.Health > 0)
            {
                playerAttack = player.AttackDice.Throw();
                enemyAttack = DefenceDice.Throw();
                damage = playerAttack - enemyAttack;

                if (damage > 0) 
                {
                    Health -= damage; 
                }
            }
        }
    }
}
