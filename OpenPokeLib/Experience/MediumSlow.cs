using System;

namespace OpenPokeLib.Experience
{
    public class MediumSlow : ILevelExperience
    {
        public int CalculateExperienceRequired(int n)
        {
            return (int)((6f/5f)*Math.Pow(n, 3) - 15*Math.Pow(n, 2) + 100*n - 140);
        }
    }
}