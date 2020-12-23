using System;

namespace OpenPokeLib.Experience
{
    public class MediumFast : ILevelExperience
    {
        public int n { get; set; }
        public int CalculateExperienceRequired()
        {
            return (int)Math.Pow(n, 3);
        }
    }
}