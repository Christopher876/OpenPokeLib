using System;

namespace OpenPokeLib.Experience
{
    public class Erratic : ILevelExperience
    {
        public int CalculateExperienceRequired(int n)
        {
            return n switch
            {
                <= 50 => (int) Math.Floor((Math.Pow(n, 3) * (100 - n)) / 50),
                <= 68 => (int) Math.Floor((Math.Pow(n, 3) * (150 - n)) / 100),
                <= 98 => (int) Math.Floor((Math.Pow(n, 3) * ((1911 - n * 10) / 3f)) / 500),
                <= 100 => (int) Math.Floor((Math.Pow(n, 3) * (160 - n)) / 100),
                _ => 0
            };
        }
    }
}