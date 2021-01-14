using System;
using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using OpenPokeLib;
using OpenPokeLib.DataManager;
using OpenPokeLib.Items;
using OpenPokeLib.Moves;
using OpenPokeLib.Pokemons;
using OpenPokeLib.Utils;

namespace TestRun
{
    class Program
    {
        static void PokemonTest()
        {
            Trainer trainer = new Trainer();
            trainer.GenerateTrainerId();

            var options = new []{"Groudon", "Charmander", "Charizard"};
            Random random = new Random();

            PC pc = new PC();
            for (int i = 0; i < 18; i++)
            {
                var option = random.Next(0, options.Length);
                var level = random.Next(0, 100);
                Pokemon pokemon = GeneratePokemon.Generate(options[option],trainer.TrainerId,trainer.SecretId);
                pokemon.Stats.Level = level;
                
                if (!trainer.AddPokemon(pokemon))
                {
                    pc.InsertPokemon(0,pokemon);
                }
            }

            foreach (var pokemon1 in trainer.Team)
            {
                Console.WriteLine(pokemon1);
            }
            
            Console.WriteLine("\n");
            foreach (var pokemon in pc.RetrieveBox(0))
            {
                Console.WriteLine(pokemon);
            }
        }
        
        static void Main(string[] args)
        {
            Trainer trainer = new Trainer();
            trainer.GenerateTrainerId();

            var options = new []{"Groudon", "Charmander", "Charizard", "Metagross"};
            Random random = new Random();
            
            //Generate a party of 6 Pokemon
            PC pc = new PC();
            for (int i = 0; i < 200; i++)
            {
                var option = random.Next(0, options.Length);
                var level = random.Next(0, 100);
                Pokemon pokemon = GeneratePokemon.Generate(options[option],trainer.TrainerId,trainer.SecretId);
                pokemon.Stats.Level = level;
                pokemon.Moves[0] = new Ember();

                if (!trainer.AddPokemon(pokemon))
                {
                    pc.InsertPokemon(random.Next(0,16),pokemon);
                }
            }
            
            DataManager.Setup(); //Check if our save file exists and set up the files if it does not
            DataManager.Load(); //Load up the entire json file into memory
            DataManager.Save(trainer,pc); //Save all of the trainer information
            DataManager.Write(); //Write all information to both .json and .bson
            DataManager.Load(); //Load up once again
        }
    }
}