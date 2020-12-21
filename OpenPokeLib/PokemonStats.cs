namespace OpenPokeLib
{
    public class PokemonStats
    {
        //Base Pokemon Stats
        private int Attack { get; set; } //0
        private int Defense { get; set; } //1
        private int SpecialAttack { get; set; } //2
        private int SpecialDefense { get; set; } //3
        private int Speed { get; set; } //4

        private int[] IVs { get; set; }
        private int[] EVs { get; set; }
        
        /// <summary>
        /// Create new Pokemon Stats with pre-generated IV values
        /// </summary>
        /// <param name="ivs">The ivs that have been generated and are going to be applied to the Pokemon</param>
        public PokemonStats(int[] ivs)
        {
            IVs = ivs.Clone() as int[];
            EVs = new int[5];
        }

        public PokemonStats(int attack, int defense, int specialAttack, int specialDefense, int speed, int[] ivs, int[] evs)
        {
            Attack = attack;
            Defense = defense;
            SpecialAttack = SpecialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
            IVs = ivs.Clone() as int[];
            EVs = evs.Clone() as int[];
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
    }
}