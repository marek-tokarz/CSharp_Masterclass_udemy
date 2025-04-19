
using System;

namespace RollDiceGame.Game
{
    public class Dice
    {
        private readonly Random _random;
        private const int SidesCount = 6;

        public Dice(Random random)
        {
            _random = random;
        }

        public int Roll()
        {
            return _random.Next(1, SidesCount + 1);
        }
    }
}