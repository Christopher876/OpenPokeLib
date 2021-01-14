using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using OpenPokeLib.Abilities;
using OpenPokeLib.Items;
using OpenPokeLib.Moves;
using OpenPokeLib.PokemonTypes;
using OpenPokeLib.Utils;

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

        public readonly PokemonInfo Info;

        public Bitmap FrontSprite => Info.Sprites[0] as Bitmap;
        public Bitmap BackSprite => Info.Sprites[1] as Bitmap;
        public Bitmap FrontShinySprite => Info.Sprites[2] as Bitmap;
        public Bitmap BackShinySprite => Info.Sprites[3] as Bitmap;
        public IItem HeldItem;

        public Pokemon(string name, Nature nature = null, int[] ivs = null, int[] evs = null)
        {
            Name = name;
            Info = new PokemonInfo(name);
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
            Moves = new Move[] {new Empty(), new Empty(), new Empty(), new Empty()};
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

        public override string ToString()
        {
            return $"{Name} {Stats.IVs[0]} {Stats.IVs[1]} {Stats.IVs[2]} {Stats.IVs[3]} {Stats.IVs[4]} {Stats.IVs[5]} {Stats.Nature} {Shiny} {Gender} Level:{Stats.Level} Ability:{Ability.Name}";
        }
    }
}