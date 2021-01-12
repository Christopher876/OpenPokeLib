using System;
using System.Collections.Generic;

namespace OpenPokeLib
{
    public class Nature
    {
        public string Up;
        public string Down;

        public Nature()
        {
            Up = String.Empty;
            Down = String.Empty;
        }

        public Nature(string up, string down)
        {
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
    }

    public class Natures
    {
        public static readonly Nature Adamant = new Nature("Attack","SpecialAttack");
        public static readonly Nature Bold = new Nature("Defense", "Attack");
        public static readonly Nature Hardy = new Nature();
        public static readonly Nature Lonely = new Nature("Attack", "Defense");
        public static readonly Nature Brave = new Nature("Attack", "Speed");
        public static readonly Nature Naughty = new Nature("Attack", "SpecialDefense");
        public static readonly Nature Docile = new Nature();
        public static readonly Nature Relaxed = new Nature("Defense", "Speed");
        public static readonly Nature Impish = new Nature("Defense", "SpecialAttack");
        public static readonly Nature Lax = new Nature("Defense", "SpecialDefense");
        public static readonly Nature Timid = new Nature("Speed", "Attack");
        public static readonly Nature Hasty = new Nature("Speed", "Defense");
        public static readonly Nature Serious = new Nature();
        public static readonly Nature Jolly = new Nature("Speed", "Attack");
        public static readonly Nature Naive = new Nature("Speed", "SpecialDefense");
        public static readonly Nature Modest = new Nature("SpecialAttack","Attack");
        public static readonly Nature Mild = new Nature("SpecialAttack", "Defense");
        public static readonly Nature Quiet = new Nature("SpecialAttack", "Speed");
        public static readonly Nature Bashful = new Nature();
        public static readonly Nature Rash = new Nature("SpecialAttack", "SpecialDefense");
        public static readonly Nature Calm = new Nature("SpecialDefense", "Attack");
        public static readonly Nature Gentle = new Nature("SpecialDefense", "Defense");
        public static readonly Nature Sassy = new Nature("SpecialDefense", "Speed");
        public static readonly Nature Careful = new Nature("SpecialDefense", "SpecialAttack");
        public static readonly Nature Quirky = new Nature();
    }
}