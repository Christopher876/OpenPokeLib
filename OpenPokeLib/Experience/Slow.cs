using System;

namespace OpenPokeLib.Experience
{
    public class Slow : ILevelExperience
    {
        public int n { get; set; }
        public int CalculateExperienceRequired()
        {
            return (int)((5*Math.Pow(n,3))/4);
        }
    }
}