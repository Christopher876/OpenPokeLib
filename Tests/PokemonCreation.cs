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
            Garchomp garchomp = new Garchomp(Natures.Adamant, new int[]{24,12,30,16,23,5}, new int[]{74,190,91,48,84,23});
            garchomp.Stats.Level = 78;
            garchomp.Stats.GenerateStats();
        }

        [Test]
        public void GetExperienceNeededToLevelUpFast()
        {
            var smeargle = new Smeargle(Natures.Adamant, new int[] {0, 0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0, 0});
            smeargle.Stats.Level = 16;
            
            //Get all of the experience gained
            smeargle.Stats.Experience.n = 16;
            var a = smeargle.Stats.Experience.CalculateExperienceRequired();
            
            //Get the next level of experience
            smeargle.Stats.Experience.n = 17;
            var b = smeargle.Stats.Experience.CalculateExperienceRequired();

            var c = b - a; // Experience needed to get to next level
            
            Assert.AreEqual(654,c);
        }
        
        [Test]
        public void GetExperienceNeededToLevelUpErratic()
        {
            var smeargle = new Smeargle(Natures.Adamant, new int[] {0, 0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0, 0});
            smeargle.Stats.Level = 16;
            
            //Get all of the experience gained
            smeargle.Stats.Experience.n = 16;
            var a = smeargle.Stats.Experience.CalculateExperienceRequired();
            
            //Get the next level of experience
            smeargle.Stats.Experience.n = 17;
            var b = smeargle.Stats.Experience.CalculateExperienceRequired();

            var c = b - a; // Experience needed to get to next level
            
            Assert.AreEqual(654,c);
        }

        [Test]
        public void GetExperienceNeededToLevelUpSlow()
        {
            var garchomp = new Garchomp(Natures.Adamant, new int[] {24, 12, 30, 16, 23, 5},
                new int[] {74, 190, 91, 48, 84, 23});
            garchomp.Stats.Level = 1;
            
            //Get all of the experience gained
            garchomp.Stats.Experience.n = 97;
            var a = garchomp.Stats.Experience.CalculateExperienceRequired();
            
            //Get the next level of experience
            garchomp.Stats.Experience.n = 98;
            var b = garchomp.Stats.Experience.CalculateExperienceRequired();

            var c = b - a; // Experience needed to get to next level
            
            Assert.AreEqual(35649,c);
        }
    }
}