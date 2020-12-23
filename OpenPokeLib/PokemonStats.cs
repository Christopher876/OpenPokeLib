using System;
using OpenPokeLib.Experience;

namespace OpenPokeLib
{
    public class PokemonStats
    {
        public int Level;
        public int Exp;

        public Nature Nature;
        //Pokemon Stats
        private int HP { get; set; }
        private int Attack { get; set; } //0
        private int Defense { get; set; } //1
        private int SpecialAttack { get; set; } //2
        private int SpecialDefense { get; set; } //3
        private int Speed { get; set; } //4
        
        // Base Pokemon Stats
        private int _baseHp;
        private int _baseAttack;
        private int _baseDefense;
        private int _baseSpecialAttack;
        private int _baseSpecialDefense;
        private int _baseSpeed;

        public ILevelExperience Experience;

        private int[] IVs { get; set; }
        private int[] EVs { get; set; }
        
        private int[] Modifiers { get; set; }

        public PokemonStats()
        {
            
        }
        
        /// <summary>
        /// Create new Pokemon Stats with pre-generated IV values
        /// </summary>
        /// <param name="ivs">The ivs that have been generated and are going to be applied to the Pokemon</param>
        public PokemonStats(int[] ivs)
        {
            IVs = ivs.Clone() as int[];
            EVs = new int[6];
            Modifiers = new int[6];
        }
        
        public PokemonStats(Nature nature, int[] ivs, int[] evs)
        {
            IVs = ivs.Clone() as int[];
            EVs = evs.Clone() as int[];
            Modifiers = new int[6];
            Nature = nature;
        }

        public PokemonStats(int hp, int attack, int defense, int specialAttack, int specialDefense, int speed, int[] ivs, int[] evs)
        {
            HP = hp;
            Attack = attack;
            Defense = defense;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
            IVs = ivs.Clone() as int[];
            EVs = evs.Clone() as int[];
            Modifiers = new int[6];
        }

        public void SetBaseStats(int hp,int attack, int defense, int specialAttack, int specialDefense, int speed)
        {
            _baseHp = hp;
            _baseAttack = attack;
            _baseDefense = defense;
            _baseSpecialAttack = specialAttack;
            _baseSpecialDefense = specialDefense;
            _baseSpeed = speed;
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

        public void GenerateStats()
        {
            int[] newStats = new int[6];
            int[] baseStats = new []
            {
                _baseAttack,
                _baseDefense,
                _baseSpecialAttack,
                _baseSpecialDefense,
                _baseSpeed
            };
            //HP
            newStats[0] = (((2 * _baseHp + IVs[0] + (EVs[0] / 4)) * Level) / 100) + Level + 10;

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
                        (int) Math.Floor(((((2 * baseStats[i-1] + IVs[i] + (EVs[i] / 4)) * Level) / 100) + 5) * 1.1f);
                }
                //Negative Multiplier
                else if (Nature.Down == statTypes[i-1])
                {
                    newStats[i] =
                        (int) Math.Floor(((((2 * baseStats[i-1] + IVs[i] + (EVs[i] / 4)) * Level) / 100) + 5) * 0.9f);
                }
                //Neutral Multiplier
                else
                {
                    newStats[i] =
                        (int) Math.Floor(((((2 * baseStats[i-1] + IVs[i] + (EVs[i] / 4)) * Level) / 100) + 5) * 1f);
                }
            }

            foreach (var stat in newStats)
            {
                Console.WriteLine(stat);
            }
        }
    }
}