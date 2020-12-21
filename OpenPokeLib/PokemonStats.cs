namespace OpenPokeLib
{
    public class PokemonStats
    {
        //Pokemon Stats
        private int HP { get; set; }
        private int Attack { get; set; } //0
        private int Defense { get; set; } //1
        private int SpecialAttack { get; set; } //2
        private int SpecialDefense { get; set; } //3
        private int Speed { get; set; } //4
        
        // Base Pokemon Stats
        private int BaseHP;
        private int BaseAttack;
        private int BaseDefense;
        private int BaseSpecialAttack;
        private int BaseSpecialDefense;
        private int BaseSpeed;

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
            BaseHP = hp;
            BaseAttack = attack;
            BaseDefense = defense;
            BaseSpecialAttack = specialAttack;
            BaseSpecialDefense = specialDefense;
            BaseSpeed = speed;
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
    }
}