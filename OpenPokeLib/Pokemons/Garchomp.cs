using System;
using OpenPokeLib.Experience;

namespace OpenPokeLib.Pokemons
{
    public class Garchomp: Pokemon
    {
        public Garchomp() : base()
        {
            Name = "Garchomp";
            NickName = "Garchomp";
            Stats.SetBaseStats(108,130,95,80,85,102);
        }

        public Garchomp(Nature nature, int[] ivs, int[] evs) : base(nature, ivs, evs)
        {
            Name = "Garchomp";
            NickName = "Garchomp";
            Stats.SetBaseStats(108,130,95,80,85,102);
            Stats.Experience = new Slow();
        }
    }
}