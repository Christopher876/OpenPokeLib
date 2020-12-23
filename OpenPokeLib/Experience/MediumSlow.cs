using System;

namespace OpenPokeLib.Experience
{
    public class MediumSlow : ILevelExperience
    {
        public int n { get; set; }
        public int CalculateExperienceRequired()
        {
            return (int)((6/5)*Math.Pow(n, 3) - 15*Math.Pow(n, 2) + 100*n - 140);
        }
    }
}