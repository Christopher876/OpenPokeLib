using System;
using OpenPokeLib.Experience;
using OpenPokeLib.Utils;

namespace OpenPokeLib
{
    public class PokemonStats
    {
        private string _name;
        public int Level;
        public int CurrentExp; //Current Exp amount since level 1

        public int NeededExpForNextLevel
        {
            get
            {
                var acquiredForLevel = Experience.CalculateExperienceRequired(Level);
                var needed = Experience.CalculateExperienceRequired(Level+1);
                var experienceRequired = needed - acquiredForLevel;
                return experienceRequired;
            }
        }
        public float Weight; //Pounds

        public Nature Nature;
        //Pokemon Stats
        private int Hp { get; set; }
        private int Attack { get; set; } //0
        private int Defense { get; set; } //1
        private int SpecialAttack { get; set; } //2
        private int SpecialDefense { get; set; } //3
        private int Speed { get; set; } //4

        public ILevelExperience Experience;

        public int[] IVs { get; set; }
        public int[] EVs { get; set; }
        
        private int[] Modifiers { get; set; }

        public int GenderThreshold;

        public PokemonStats(string name)
        {
            
        }
        
        /// <summary>
        /// Create new Pokemon Stats with pre-generated IV values
        /// </summary>
        /// <param name="ivs">The ivs that have been generated and are going to be applied to the Pokemon</param>
        public PokemonStats(string name, int[] ivs)
        {
            IVs = ivs.Clone() as int[];
            EVs = new int[6];
            Modifiers = new int[6];
        }
        
        public PokemonStats(string name, Nature nature, int[] ivs, int[] evs)
        {
            _name = name;
            IVs = ivs.Clone() as int[];
            EVs = evs.Clone() as int[];
            Modifiers = new int[6];
            Nature = nature;
        }

        public PokemonStats(int hp, int attack, int defense, int specialAttack, int specialDefense, int speed, int[] ivs, int[] evs)
        {
            Hp = hp;
            Attack = attack;
            Defense = defense;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
            IVs = ivs.Clone() as int[];
            EVs = evs.Clone() as int[];
            Modifiers = new int[6];
        }

        public int GetIv(int stat)
        {
            return IVs[stat];
        }

        public int GetEv(int stat)
        {
            return EVs[stat];
        }

        public void SetEv(int stat, int amount)
        {
            EVs[stat] += amount;
        }

        public void SetModifier(int stat, int amount)
        {
            Modifiers[stat] += amount;
        }

        public void GenerateStats(PokemonInfo info)
        {
            int[] newStats = new int[6];
            //HP
            newStats[0] = (((2 * info.BaseStats[0] + IVs[0] + (EVs[0] / 4)) * Level) / 100) + Level + 10;

            string[] statTypes = new[]
            {
                "Attack",
                "Defense",
                "SpecialAttack",
                "SpecialDefense",
                "Speed"
            };
            for (int i = 1; i < 6; i++)
            {
                //Positive Multiplier
                if (Nature.Up == statTypes[i-1])
                {
                    newStats[i] =
                        (int) Math.Floor(((((2 * info.BaseStats[i] + IVs[i] + (EVs[i] / 4)) * Level) / 100) + 5) * 1.1f);
                }
                //Negative Multiplier
                else if (Nature.Down == statTypes[i-1])
                {
                    newStats[i] =
                        (int) Math.Floor(((((2 * info.BaseStats[i] + IVs[i] + (EVs[i] / 4)) * Level) / 100) + 5) * 0.9f);
                }
                //Neutral Multiplier
                else
                {
                    newStats[i] =
                        (int) Math.Floor(((((2 * info.BaseStats[i] + IVs[i] + (EVs[i] / 4)) * Level) / 100) + 5) * 1f);
                }
            }

            Hp = newStats[0];
            Attack = newStats[1];
            Defense = newStats[2];
            SpecialAttack = newStats[3];
            SpecialDefense = newStats[4];
            Speed = newStats[5];
        }
    }
}