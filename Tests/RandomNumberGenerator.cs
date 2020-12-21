using System;
using NUnit.Framework;
using OpenPokeLib;

namespace Tests
{
    public class RandomNumberGenerator
    {
        [Test]
        public void GenerateNumbers()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(OpenPokeLib.RandomNumberGenerator.GetNumberMT());
            }
        }
    }
}