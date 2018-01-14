using System;

namespace DURPSBot
{
    class Dice
    {
        Random rng = new Random();

        public Random Rng { get => rng; set => rng = value; }

        public int[] Roll(int numDice, int numSides)
        {
            int[] results = new int[numDice];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = Rng.Next(numSides) + 1;
            }
            return results;
        }

        public long RollTotal(int numDice, int numSides)
        {
            long total = 0;
            for (int i = 0; i < numDice; i++)
            {
                total += Rng.Next(numSides) + 1;
            }
            return total;
        }
    }
}