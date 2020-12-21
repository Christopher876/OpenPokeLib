using System;
using MersenneTwister;

namespace OpenPokeLib
{
    public class RandomNumberGenerator
    {
        private static int[] numbers = new int[624];
        private static int pointer = 0;

        private static void GenerateNumbersMT()
        {
            Random random;
            for (int i = 0; i < 624; i++)
            {
                numbers[i] = MersenneTwister.MTRandom.Create().Next();
            }
        }

        public static int GetNumberMT()
        {
            if (pointer > 624)
            {
                GenerateNumbersMT();
                pointer = 0;
            }
            else if (pointer == 0)
            {
                GenerateNumbersMT();
            }
            var number = numbers[pointer];
            pointer++;
            return number;
        }
    }
}