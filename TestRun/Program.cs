using System;
using System.Linq;
using OpenPokeLib;
using OpenPokeLib.Items;
using OpenPokeLib.Pokemons;

namespace TestRun
{
    class Program
    {
        static void Main(string[] args)
        {
            Trainer trainer = new Trainer(null);
            trainer.GenerateTrainerId();

            for (int h = 0; h < 100; h++)
            {
                for (int i = 0; i < 100_000_000; i++)
                {
                    Random ranom = new Random();
                    var options = new []{"Charizard","Groudon","Makuhita","Hariyama","Charmander"};
                    var pokemon = GeneratePokemon.Generate(options[ranom.Next(0,options.Length)], trainer.TrainerId, trainer.SecretId);
                    if (pokemon.Shiny)
                    {
                        Console.WriteLine($"Generated shiny {pokemon.Name} after {i} with {pokemon.Ability}");
                        var types = "";
                        foreach (var t in pokemon.Types)
                        {
                            types += t + " ";
                        }
                        foreach (var iv in pokemon.Stats.IVs)
                        {
                            Console.Write(iv + " ");
                        }

                        Console.WriteLine($"{types} {pokemon.Gender} \n");
                        break;
                    }
                }
            }
        }
    }
}