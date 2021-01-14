using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using OpenPokeLib.Items;

namespace OpenPokeLib
{
    public class Trainer
    {
        public string Name;
        public Pokemon[] Team;
        private int _pokemonCount;
        public IItem Items;
        public ushort TrainerId;
        public ushort SecretId;
        public Vector3 position;

        public Trainer()
        {
            Team = new Pokemon[6];
            _pokemonCount = 0;
        }

        public bool AddPokemon(Pokemon pokemon)
        {
            if (_pokemonCount < 6)
            {
                Team[_pokemonCount] = pokemon;
                _pokemonCount++;
                return true;
            }
            else
            {
                Console.WriteLine("Pokemon Storage full, remove one to add another");
                return false;
            }
        }

        public Pokemon GrabPokemon(int num)
        {
            Pokemon pokemon = Team[num];
            Team[num] = null;
            return Team[num];
        }

        public void GenerateTrainerId()
        {
            Random random = new Random();
            TrainerId = Convert.ToUInt16(random.Next(65_536));
            SecretId = Convert.ToUInt16(random.Next(65_536));
        }
    }
}