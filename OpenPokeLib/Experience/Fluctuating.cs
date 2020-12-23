using System;

namespace OpenPokeLib.Experience
{
    public class Fluctuating : ILevelExperience
    {
        public int n { get; set; }
        public int CalculateExperienceRequired()
        {
            if (n <= 15)
                return (int) (Math.Pow(n, 3) * (((n + 1) / 3) + 24) / 50);
            else if (15 <= n && n <= 36)
                return (int) (Math.Pow(n, 3) * ((n + 14) / 50));
            else if (36 <= n && n <= 100)
                return (int) (Math.Pow(n, 3) * ((n / 2 + 32) / 50));
            else
                return 0;
        }
    }
}