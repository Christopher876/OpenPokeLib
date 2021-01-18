using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using OpenPokeLib.Abilities;
using OpenPokeLib.Items;
using OpenPokeLib.Moves;
using OpenPokeLib.Pokemons;
using OpenPokeLib.PokemonTypes;
using OpenPokeLib.Utils;

namespace OpenPokeLib
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public ushort OGTrainerID { get; set; }
        public string OGTrainerCountry { get; set; }
        public bool Shiny { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Exp { get; set; }
        public PokemonStats Stats { get; set; }
        private EvolutionTrigger[] EvolutionTrigger => Info.EvolutionTriggers as EvolutionTrigger[];
        public Move[] Moves;
        public Effects Effect;

        public Gender Gender;
        public IPokemonType[] Types;
        public Ability Ability;

        public int turns = 0;
        public int PoisonTurns = 0;

        public PokemonInfo Info { get; private set; }

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

            Stats.Experience = Info.LevelingRate;
        }

        public virtual void Update()
        {
            turns++; //Track the number of turns this Pokemon has done
            CheckStatus();
        }

        //Check this at the end of battle to see if we have the correct level to level up with
        public virtual void CheckEvolution()
        {
            //Check the trigger and then evolve if we meet the condition
            if (Stats.Level >= Info.EvolutionLevel && Info.EvolutionLevel != -1)
            {
                Evolve();
            }
        }

        public void GainExp(int exp)
        {
            Stats.CurrentExp += exp;
            while (Stats.NeededExpForNextLevel < exp)
            {
                exp -= Stats.NeededExpForNextLevel;
                Stats.Level++;
            }
            
            CheckEvolution();
        }

        private void Evolve()
        {
            PokemonInfo info = new PokemonInfo(Info.Evolution); //Let's get the next evolution
            Name = Info.Evolution; //Set the current name to that Pokemon
            Stats.GenerateStats(info); //Generate the new Pokemon stats and apply it
            Types = info.GetTypes(); //Select our new type
            Ability = info.GetAbility(0); //TODO fix this to select correct ability in the future with Hidden Abilities
            Info = info; //Set the current information to the evolution
        }

        public void Generate(string name, bool shiny, int[] ivs, Nature nature, Gender gender, Ability ability, IPokemonType[] types, ushort ogTrainerID)
        {
            OGTrainerID = ogTrainerID;
            Gender = gender;
            Stats.IVs = ivs.Clone() as int[];
            Stats.Nature = nature;
            Stats.EVs = new int[6];
            Shiny = shiny;
            Ability = ability;
            Types = types;
            Moves = new Move[] {new Empty(), new Empty(), new Empty(), new Empty()};

            //TODO HANDLE HELD ITEMS FOR WILD POKEMON
            HeldItem = new Item("Potion");
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