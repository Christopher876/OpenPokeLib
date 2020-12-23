using System;

namespace OpenPokeLib.Experience
{
    public class Fast : ILevelExperience
    {
        public int n { get; set; }
        public int CalculateExperienceRequired()
        {
            return (int)(4 * Math.Pow(n, 3)) / 5;
        }
    }
}