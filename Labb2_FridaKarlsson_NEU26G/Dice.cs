

namespace Labb2_FridaKarlsson_NEU26G
{ 
    internal class Dice
    {
        public int numberOfDice = 0;
        public int sidesPerDice = 0;
        public int modifier = 0;
        public Dice(int numberOfDice, int sidesPerDice, int modifier)
        {
            this.numberOfDice = numberOfDice;
            this.sidesPerDice = sidesPerDice;
            this.modifier = modifier;
        }

        public int Throw()
        {
            int result = 0;
            for (int i = 0; i < numberOfDice; i++)
            {
                result += Random.Shared.Next(1, this.sidesPerDice + 1);
            }
            return result + modifier;
        }

        public override string ToString()
        {
            return $"({numberOfDice}d{sidesPerDice}+{modifier})";
        }
        }
    }

