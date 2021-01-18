using System;

namespace OpenPokeLib.Experience
{
    public class Slow : ILevelExperience
    {
        public int CalculateExperienceRequired(int n)
        {
            return (int)((5*Math.Pow(n,3))/4);
        }
    }
}