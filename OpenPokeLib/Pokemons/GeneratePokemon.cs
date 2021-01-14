using System;
using OpenPokeLib.Abilities;
using OpenPokeLib.Utils;

namespace OpenPokeLib.Pokemons
{
    public class GeneratePokemon
    {
        private static UInt32 Generate32BitNumber()
        {
            Random random = new Random();
            
            byte[] bytes = new byte[8];
            random.NextBytes(bytes);
            return BitConverter.ToUInt32(bytes);
        }

        private static Gender GenerateGender(uint pGender, int threshold)
        {
            if (threshold == 0) return Gender.Male;
            else if (threshold == 255) return Gender.Genderless;
            else if (threshold == 254) return Gender.Female;
            else return (pGender > threshold) ?  Gender.Male: Gender.Female;
        }
        
        /// <summary>
        /// Decides whether the Pokemon's ability should be the first or the second
        /// </summary>
        /// <param name="pAbility"></param>
        /// <returns>0 indicating first ability otherwise 1 for second ability</returns>
        private static int GenerateAbility(int pAbility)
        {
            return (pAbility == 0) ? 0 : 1;
        }
        
        public static Nature GenerateNature(uint n)
        {
            if (n == 0) return Natures.Adamant;
            else if (n == 1) return Natures.Bold;
            else if (n == 2) return Natures.Hardy;
            else if (n == 3) return Natures.Lonely;
            else if (n == 4) return Natures.Brave;
            else if (n == 5) return Natures.Naughty;
            else if (n == 6) return Natures.Docile;
            else if (n == 7) return Natures.Relaxed;
            else if (n == 8) return Natures.Impish;
            else if (n == 9) return Natures.Lax;
            else if (n == 10) return Natures.Timid;
            else if (n == 11) return Natures.Hasty;
            else if (n == 12) return Natures.Serious;
            else if (n == 13) return Natures.Jolly;
            else if (n == 14) return Natures.Naive;
            else if (n == 15) return Natures.Modest;
            else if (n == 16) return Natures.Mild;
            else if (n == 17) return Natures.Quiet;
            else if (n == 18) return Natures.Bashful;
            else if (n == 19) return Natures.Rash;
            else if (n == 20) return Natures.Calm;
            else if (n == 21) return Natures.Gentle;
            else if (n == 22) return Natures.Sassy;
            else if (n == 23) return Natures.Careful;
            else if (n == 24) return Natures.Quirky;
            else return null;
        }
        
        public static Pokemon Generate(string name, int trainerID, int secretID)
        {
            Random random = new Random();
            Pokemon pokemon = Activator.CreateInstance(Type.GetType("OpenPokeLib.Pokemons" + "." + name) ?? typeof(Charmander)) as Pokemon;
            PokemonInfo info = new PokemonInfo(name);

            //Generate Personality Value
            var p = Generate32BitNumber();

            //Gender
            var pGender = p % 256;
            var gender = GenerateGender(pGender, info.GenderThreshold);
            
            //Ability
            var pAbility = (int)Math.Floor((double) (p/65536 % 2));
            var abilitySelector = GenerateAbility(pAbility);
            Ability ability = info.Abilities.Count == 1 ? info.GetAbility(0) : info.GetAbility(abilitySelector);
            //Ability ability = new Blaze();
            
            //Nature
            var pNature = p % 25;
            var nature = GenerateNature(pNature);
            
            //Shiny
            var p1 = Convert.ToUInt16(p / 65536);
            var p2 = Convert.ToUInt16(p % 65536);
            var s = Convert.ToUInt16((trainerID ^ secretID) ^ (p1 ^ p2));
            var shiny = (s < 16);
            
            //Generate the IVs
            int[] ivs = new int[6];
            for (int i = 0; i < 6; i++)
            {
                ivs[i] = random.Next(0, 32);
            }
            
            //Select the type
            var type = info.GetTypes();
            
            //Generate Pokemon
            pokemon?.Generate(shiny,ivs,nature, gender, ability, type);
            pokemon?.Stats.GenerateStats(info);
            return pokemon;
        }
    }
}