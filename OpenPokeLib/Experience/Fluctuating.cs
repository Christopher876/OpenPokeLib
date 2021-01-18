using System;

namespace OpenPokeLib.Experience
{
    public class Fluctuating : ILevelExperience
    {
        public int CalculateExperienceRequired(int n)
        {
            return n switch
            {
                <= 15 => (int) (Math.Pow(n, 3) * (((n + 1) / 3) + 24) / 50),
                <= 36 => (int) (Math.Pow(n, 3) * ((n + 14f) / 50)),
                <= 100 => (int) (Math.Pow(n, 3) * (((n / 2f) + 32f) / 50)),
                _ => 0
            };
        }
    }
}