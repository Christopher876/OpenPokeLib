using System;

namespace OpenPokeLib.Experience
{
    public class Fast : ILevelExperience
    {
        public int CalculateExperienceRequired(int n)
        {
            return (int)(4 * Math.Pow(n, 3)) / 5;
        }
    }
}