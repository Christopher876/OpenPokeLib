using System;

namespace OpenPokeLib.Experience
{
    public class Erratic : ILevelExperience
    {
        public int n { get; set; }
        
        public int CalculateExperienceRequired()
        {
            if(n <= 50)
                return (int) Math.Floor((Math.Pow(n, 3) * (100 - n)) / 50);
            else if(50 <= n && n <= 68 )
                return (int) Math.Floor((Math.Pow(n, 3) * (150 - n)) / 100);
            else if(68 <= n && n <= 98)
                return (int) Math.Floor((Math.Pow(n, 3) * ((1911 - n * 10) / 3)) / 500);
            else if(98 <= n && n <= 100)
                return (int) Math.Floor((Math.Pow(n, 3) * (160 - n)) / 100);
            else
            {
                return 0;
            }
        }
    }
}