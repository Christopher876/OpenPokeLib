using System;
using System.Diagnostics;
using OpenPokeLib.Moves;

namespace OpenPokeLib
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Exp { get; set; }
        public PokemonStats Stats { get; set; }
        public Move[] Moves;
        public Effects Effect;

        public int turns = 0;
        public int PoisonTurns = 0;

        public Pokemon()
        {
            Stats = new PokemonStats();
        }

        public virtual void Update()
        {
            turns++; //Track the number of turns this Pokemon has done
            CheckStatus();
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