using System;

namespace OpenPokeLib.Formulas
{
    public class Experience
    {
        public static int HP(int hpBase, int iv, int ev, int level)
        {
            int result = (((2 * hpBase + iv + (ev / 4)) * level) / 100) + level + 10;
            return result;
        }

        public static int OtherStat(int stat, int iv, int ev, int level, Nature nature)
        {
            float multiplier = 1.1f;
            if (stat == 1 && nature.Up == "Attack")
            {
                multiplier = 1.1f;
            }
            else if (stat == 1 && nature.Down == "Attack")
            {
                multiplier = 0.9f;
            }
            else if (stat == 2 && nature.Up == "Defense")
            {
                multiplier = 1.1f;
            }
            else if (stat == 2 && nature.Down == "Defense")
            {
                multiplier = 0.9f;
            }
            else if (stat == 3 && nature.Up == "SpecialAttack")
            {
                multiplier = 1.1f;
            }
            else if (stat == 3 && nature.Down == "SpecialAttack")
            {
                multiplier = 0.9f;
            }
            else if (stat == 4 && nature.Up == "SpecialDefense")
            {
                multiplier = 1.1f;
            }
            else if (stat == 4 && nature.Down == "SpecialDefense")
            {
                multiplier = 0.9f;
            }
            else if (stat == 5 && nature.Up == "Speed")
            {
                multiplier = 1.1f;
            }
            else if (stat == 5 && nature.Down == "Speed")
            {
                multiplier = 0.9f;
            }
            
            int result = (int)Math.Floor(((((2 * stat + iv + (ev / 4)) * level) / 100) + 5) * multiplier);
            return result;
        }
    }
}