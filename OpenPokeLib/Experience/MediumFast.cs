using System;

namespace OpenPokeLib.Experience
{
    public class MediumFast : ILevelExperience
    {
        public int CalculateExperienceRequired(int n)
        {
            return (int)Math.Pow(n, 3);
        }
    }
}