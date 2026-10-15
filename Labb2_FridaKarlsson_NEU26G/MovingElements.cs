


namespace Labb2_FridaKarlsson_NEU26G
{
    internal abstract class MovingElements : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }
        public int previousPositionX { get; set; }
        public int previousPositionY { get; set; }
        public bool WasInAFight { get; set; }

        public MovingElements(int x, int y, char character, ConsoleColor color, string name, int hp, Dice attack, Dice defence) : base(x, y, character, color)
        {
            Name = name;
            Health = hp;
            AttackDice = attack;
            DefenceDice = defence;
            previousPositionX = x;
            previousPositionY = y;
        }

        public override void Draw()
        {
            if (xPosition != previousPositionX || yPosition != previousPositionY)
            {
                Console.SetCursorPosition(previousPositionX, previousPositionY + 4);
                Console.Write(' ');
            }

            Console.SetCursorPosition(xPosition, yPosition + 4); Console.ForegroundColor = color; Console.Write(character); Console.ResetColor();
            previousPositionX = xPosition;
            previousPositionY = yPosition;
        }


        public void Attack(MovingElements target)
        {
            string attackerNameUp = this is Player ? "You" : this.Name;
            string attackerNameLow = this is Player ? "you" : this.Name;
            string defenderNameUp = target is Player ? "You" : target.Name;
            string defenderNameLow = target is Player ? "you" : target.Name;

            int attacker = this.AttackDice.Throw();
            int defender = target.DefenceDice.Throw();
            int damage = attacker - defender;

            if (damage > 0) { target.Health -= damage; }

            string firstRound = Damage(damage, target);
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = this.color;
            Console.WriteLine($"{attackerNameUp} ({this.AttackDice}) attacked {defenderNameLow} ({target.DefenceDice}), {firstRound}".PadRight(Console.WindowWidth));
            Console.ResetColor();


            if (target.Health > 0)
            {
                defender = target.AttackDice.Throw();
                attacker = this.DefenceDice.Throw();
                damage = defender - attacker;

                if (damage > 0) { this.Health -= damage; }

                string secondRound = Damage(damage, this);
                Console.SetCursorPosition(0, 2);
                Console.ForegroundColor = target.color;
                Console.WriteLine($"{defenderNameUp} ({target.AttackDice}) hit back at {attackerNameLow} ({this.DefenceDice}), {secondRound}".PadRight(Console.WindowWidth));
                Console.ResetColor();                
            }   
        }

        private string Damage(int damage, MovingElements target)
        {
            string it = target is Player ? "you" : "it";

            switch (damage)
            {
                case <= 0:
                    return "but did not manage to make any damage.";
                case <5:
                    return $"slightly wounding {it}.";
                case < 10:
                    return $"moderately wounding {it}.";
                case >= 10:
                    return $"severly wounding  {it}.";
            }
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
