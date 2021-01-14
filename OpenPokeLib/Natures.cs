using System;
using System.Collections.Generic;

namespace OpenPokeLib
{
    public class Nature
    {
        public string Name;
        public string Up;
        public string Down;

        public Nature(string name)
        {
            Name = name;
            Up = String.Empty;
            Down = String.Empty;
        }

        public Nature(string name,string up, string down)
        {
            Name = name;
            Up = up;
            Down = down;
        }

        public float GetPositive()
        {
            return 1.1f;
        }

        public float GetNegative()
        {
            return 0.9f;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Natures
    {
        public static readonly Nature Adamant = new Nature("Adamant","Attack","SpecialAttack");
        public static readonly Nature Bold = new Nature("Bold","Defense", "Attack");
        public static readonly Nature Hardy = new Nature("Hardy");
        public static readonly Nature Lonely = new Nature("Lonely","Attack", "Defense");
        public static readonly Nature Brave = new Nature("Brave","Attack", "Speed");
        public static readonly Nature Naughty = new Nature("Naughty","Attack", "SpecialDefense");
        public static readonly Nature Docile = new Nature("Docile");
        public static readonly Nature Relaxed = new Nature("Relaxed","Defense", "Speed");
        public static readonly Nature Impish = new Nature("Impish","Defense", "SpecialAttack");
        public static readonly Nature Lax = new Nature("Lax","Defense", "SpecialDefense");
        public static readonly Nature Timid = new Nature("Timid","Speed", "Attack");
        public static readonly Nature Hasty = new Nature("Hasty","Speed", "Defense");
        public static readonly Nature Serious = new Nature("Serious");
        public static readonly Nature Jolly = new Nature("Jolly","Speed", "Attack");
        public static readonly Nature Naive = new Nature("Naive","Speed", "SpecialDefense");
        public static readonly Nature Modest = new Nature("Modest","SpecialAttack","Attack");
        public static readonly Nature Mild = new Nature("Mild","SpecialAttack", "Defense");
        public static readonly Nature Quiet = new Nature("Quiet","SpecialAttack", "Speed");
        public static readonly Nature Bashful = new Nature("Bashful");
        public static readonly Nature Rash = new Nature("Rash","SpecialAttack", "SpecialDefense");
        public static readonly Nature Calm = new Nature("Calm","SpecialDefense", "Attack");
        public static readonly Nature Gentle = new Nature("Genetle","SpecialDefense", "Defense");
        public static readonly Nature Sassy = new Nature("Sassy","SpecialDefense", "Speed");
        public static readonly Nature Careful = new Nature("Careful","SpecialDefense", "SpecialAttack");
        public static readonly Nature Quirky = new Nature("Quirky");
    }
}