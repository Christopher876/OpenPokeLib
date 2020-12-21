using System;
using OpenPokeLib.Formulas;

namespace OpenPokeLib.Pokemons
{
    public class Garchomp: Pokemon
    {
        public Garchomp() : base()
        {
            Name = "Garchomp";
            NickName = "Garchomp";
            Level = 78;
            
            Stats.SetBaseStats(108,130,95,80,85,102);
            int o = Experience.OtherStat(130,12,190,78,Natures.Adamant);
            Console.WriteLine(o);
        }
    }
}