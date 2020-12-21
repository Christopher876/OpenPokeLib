using System;
using System.Collections.Generic;

namespace OpenPokeLib
{
    public enum Natures
    {
        Hardy,
        Lonely,
        Brave,
        Adamant,
        Naughty,
        Bold,
        Docile,
        Relaxed,
        Impish,
        Lax,
        Timid,
        Hasty,
        Serious,
        Jolly,
        Naive,
        Modest,
        Mild,
        Quiet,
        Bashful,
        Rash,
        Calm,
        Gentle,
        Sassy,
        Careful,
        Quirky
    }

    public class Nature
    {
        public static Dictionary<Natures, Tuple<string, string>> dict = new Dictionary<Natures, Tuple<string, string>>()
        {
            {Natures.Hardy,new Tuple<string, string>("","")},
            {Natures.Lonely,new Tuple<string, string>("Attack","Defense")},
            {Natures.Adamant, new Tuple<string, string>("","")}
        };
    }
}