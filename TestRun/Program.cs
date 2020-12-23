using System;
using OpenPokeLib;
using OpenPokeLib.Pokemons;

namespace TestRun
{
    class Program
    {
        static void Main(string[] args)
        {
            Garchomp garchomp = new Garchomp(Natures.Adamant, new int[]{24,12,30,16,23,5}, new int[]{74,190,91,48,84,23});
            garchomp.Stats.Level = 78;
            garchomp.Stats.GenerateStats();
            Console.WriteLine("-----");
        }
    }
}