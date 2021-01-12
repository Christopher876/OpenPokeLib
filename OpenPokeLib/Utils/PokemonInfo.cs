using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenPokeLib.Abilities;
using OpenPokeLib.Experience;
using OpenPokeLib.PokemonTypes;
using System.Reflection;

namespace OpenPokeLib.Utils
{
    public class PokemonInfo
    {
        private JObject pokemonJson;

        public int[] BaseStats
        {
            get
            {
                var stats = pokemonJson["BaseStats"];
                var baseStats = new int[6];

                int i = 0;
                foreach (var stat in stats.Values())
                {
                    baseStats[i] = (int)stat;
                    i++;
                }
                return baseStats;
            }
        }

        public List<string> Types
        {
            get
            {
                List<string> t = new List<string>();
                var types = pokemonJson["Types"];
                foreach (var ability in types)
                {
                    t.Add(ability.ToString());
                }
                return t;
            }
        }

        public int GenderThreshold => (int)pokemonJson["GenderThreshold"];
        public int CatchRate => (int) pokemonJson["CatchRate"];
        public List<string> EggGroups
        {
            get
            {
                var groups = pokemonJson["EggGroups"];
                var eggGroups = new List<string>();
                foreach (var group in groups)
                {
                    eggGroups.Add(group.ToString());
                }

                return eggGroups;
            }
        }

        public int[] HatchTime
        {
            get
            {
                var times = pokemonJson["HatchTime"];
                var hatchTimes = new int[2];

                int i = 0;
                foreach (var time in times)
                {
                    hatchTimes[i] = (int)time;
                    i++;
                }

                return hatchTimes;
            }
        }

        public float Height => (float) pokemonJson["Height"];
        public float Weight => (float) pokemonJson["Weight"];
        public int BaseExperienceYield => (int) pokemonJson["BaseExperienceYield"];
        public ILevelExperience LevelingRate
        {
            get
            {
                var rate = pokemonJson["LevelingRate"];
                var levelingRate =
                    Activator.CreateInstance(Type.GetType("OpenPokeLib.Experience." + rate) ?? typeof(Slow)) as
                        ILevelExperience;
                return levelingRate;
            }
        }

        public List<Tuple<string, int>> EVYield
        {
            get
            {
                var yield = pokemonJson["EVYield"].ToArray();
                var evYield = new List<Tuple<string, int>>();
                return evYield;
            }
            
        }
        public int BaseFriendship => (int) pokemonJson["BaseFriendship"];
        public List<string> Abilities
        {
            get
            {
                List<string> ab = new List<string>();
                var abilities = pokemonJson["Abilities"];
                foreach (var ability in abilities)
                {
                    ab.Add(ability.ToString());
                }
                return ab;
            }
        }

        public string Evolution => pokemonJson["Evolution"].ToString();
        public int EvolutionLevel => (int) pokemonJson["EvolutionLevel"];
        public string Description => pokemonJson["Description"].ToString();

        public PokemonInfo(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            if (assembly is not null)
            {
                var resourceStream =
                    assembly.GetManifestResourceStream($"OpenPokeLib.Resources.Pokemon.{name}.json");
                using StreamReader file = new StreamReader(resourceStream);
                using JsonTextReader reader = new JsonTextReader(file);
                pokemonJson = (JObject) JToken.ReadFrom(reader);
            }
        }

        public Ability GetAbility(int num)
        {
            var ab = pokemonJson["Abilities"]?[num];
            var ability = Activator.CreateInstance(Type.GetType("OpenPokeLib.Abilities" + "." + ab) ?? typeof(Blaze)) as Ability;
            return ability;
        }

        public IPokemonType[] GetTypes()
        {
            IPokemonType type1 = Activator.CreateInstance(Type.GetType("OpenPokeLib.PokemonTypes." + Types[0]) ??
                                                 typeof(Unknown)) as IPokemonType;
            IPokemonType type2;
            if (Types.Count > 1)
            {
                type2 = Activator.CreateInstance(Type.GetType("OpenPokeLib.PokemonTypes." + Types[1]) ?? typeof(Unknown)) as IPokemonType;
                return new[]
                {
                    type1,
                    type2
                };
            }
            else
            {
                return new[]
                {
                    type1
                };
            }
        }
    }
}