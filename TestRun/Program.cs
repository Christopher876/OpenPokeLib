using System;
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
                    var pokemon = GeneratePokemon.Generate("Charmander", trainer.TrainerId, trainer.SecretId);
                    if (pokemon.Shiny)
                    {
                        Console.WriteLine("Generated shiny after " + i);
                        foreach (var iv in pokemon.Stats.IVs)
                        {
                            Console.Write(iv + " ");
                        }
                        Console.WriteLine($"${pokemon.Ability} {pokemon.Gender} \n");
                        break;
                    }
                }
            }
        }
    }
}