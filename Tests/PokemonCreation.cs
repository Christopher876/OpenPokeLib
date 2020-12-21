using System;
using NUnit.Framework;
using OpenPokeLib;
using OpenPokeLib.Pokemons;

namespace Tests
{
    public class PokemonCreation
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateBase()
        {
            Pokemon pokemon = new Pokemon();
        }

        [Test]
        public void CreateGarchomp()
        {
            Garchomp garchomp = new Garchomp();
            Console.WriteLine("-----");
        }
    }
}