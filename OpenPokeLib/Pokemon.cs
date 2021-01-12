using System;
using System.Diagnostics;
using OpenPokeLib.Abilities;
using OpenPokeLib.Moves;
using OpenPokeLib.PokemonTypes;

namespace OpenPokeLib
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public bool Shiny { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Exp { get; set; }
        public PokemonStats Stats { get; set; }
        public Move[] Moves;
        public Effects Effect;

        public Gender Gender;
        public IPokemonType[] Types;
        public Ability Ability;

        public int turns = 0;
        public int PoisonTurns = 0;

        public Pokemon(string name, Nature nature = null, int[] ivs = null, int[] evs = null)
        {
            Name = name;
            if (ivs != null && evs != null)
            {
                Stats = new PokemonStats(name,nature, ivs, evs);
            }
            else if (ivs != null)
            {
                Stats = new PokemonStats(name,ivs);
            }
            else
            {
                Stats = new PokemonStats(name);
            }
        }

        public virtual void Update()
        {
            turns++; //Track the number of turns this Pokemon has done
            CheckStatus();
        }

        public void Generate(bool shiny, int[] ivs, Nature nature, Gender gender, Ability ability, IPokemonType[] types)
        {
            Gender = gender;
            Stats.IVs = ivs.Clone() as int[];
            Stats.Nature = nature;
            Stats.EVs = new int[6];
            Shiny = shiny;
            Ability = ability;
            Types = types;
        }

        private void CheckStatus()
        {
            int loss = 0;
            int random = 0;
            switch(Effect)
            {
                case Effects.Paralyzed:
                    random = new Random().Next(0, 101);
                    if (random <= 25)
                    {
                        //TODO Get paralyzed this turn
                        Console.WriteLine($"{Name} is paralyzed! It can't move!");
                    }
                    break;
                case Effects.Poisoned:
                    loss = MaxHealth / 16; // 1/16 health
                    Health -= loss;
                    break;
                case Effects.BadlyPoisoned:
                    PoisonTurns++;
                    loss = (MaxHealth / 16) * PoisonTurns; // 1/16 * PoisionTurns
                    Health -= loss;
                    break;
                case Effects.Burned:
                    loss = MaxHealth / 8; // 1/16 health
                    Health -= loss;
                    break;
                case Effects.Frozen:
                    random = new Random().Next(0, 101);
                    if (random <= 20)
                    {
                        //TODO Get Frozen this turn
                        Console.WriteLine($"{Name} is frozen! It can't move!");
                    }
                    break;
                case Effects.Sleep:
                    //TODO Fix Sleep
                    break;
                case Effects.Flinch:
                    break;
                case Effects.Confused:
                    break;
                case Effects.Infatuation:
                    break;
                case Effects.LeechSeed:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}