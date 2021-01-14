using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenPokeLib
{
    public class PC
    {
        private Dictionary<int, List<Pokemon>> Boxes;
        public readonly int MaxBoxCount = 16;

        public PC()
        {
            Boxes = new Dictionary<int, List<Pokemon>>();
            
            //Create 16 Pokemon Storage Boxes
            for (int i = 0; i < 16; i++)
            {
                Boxes[i] = new List<Pokemon>();
            }
        }

        public bool InsertPokemon(int boxNum, Pokemon pokemon)
        {
            //Add Pokemon to specific box
            if (Boxes[boxNum].Count() < 30)
            {
                Boxes[boxNum].Add(pokemon);
                return true;
            }
            else
            {
                Console.WriteLine("Cannot add Pokemon to Box");
                return false;
            }
        }

        public List<Pokemon> RetrieveBox(int boxNum)
        {
            var pokemons = new List<Pokemon>();
            foreach (var pokemon in Boxes[boxNum])
            {
                pokemons.Add(pokemon);
            }

            return pokemons;
        }
    }
}