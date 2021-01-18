using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenPokeLib.Abilities;
using OpenPokeLib.Experience;
using OpenPokeLib.PokemonTypes;
using System.Reflection;
using OpenPokeLib.Pokemons;

namespace OpenPokeLib.Utils
{
    public class PokemonInfo
    {
        private readonly JObject _pokemonJson;
        public Image[] Sprites;

        public int[] BaseStats
        {
            get
            {
                var stats = _pokemonJson["BaseStats"];
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
                var types = _pokemonJson["Types"];
                foreach (var ability in types)
                {
                    t.Add(ability.ToString());
                }
                return t;
            }
        }

        public int GenderThreshold => (int)_pokemonJson["GenderThreshold"];
        public int CatchRate => (int) _pokemonJson["CatchRate"];
        public List<string> EggGroups
        {
            get
            {
                var groups = _pokemonJson["EggGroups"];
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
                var times = _pokemonJson["HatchTime"];
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

        public float Height => (float) _pokemonJson["Height"];
        public float Weight => (float) _pokemonJson["Weight"];
        public int BaseExperienceYield => (int) _pokemonJson["BaseExperienceYield"];
        public ILevelExperience LevelingRate
        {
            get
            {
                var rate = _pokemonJson["LevelingRate"];
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
                var yield = _pokemonJson["EVYield"].ToArray();
                var evYield = new List<Tuple<string, int>>();
                return evYield;
            }
            
        }
        public int BaseFriendship => (int) _pokemonJson["BaseFriendship"];
        public List<string> Abilities
        {
            get
            {
                List<string> ab = new List<string>();
                var abilities = _pokemonJson["Abilities"];
                foreach (var ability in abilities)
                {
                    ab.Add(ability.ToString());
                }
                return ab;
            }
        }

        public string Evolution => _pokemonJson["Evolution"].ToString();
        public int EvolutionLevel => (int) _pokemonJson["EvolutionLevel"];

        public IEnumerable<EvolutionTrigger> EvolutionTriggers
        {
            get
            {
                var triggers = _pokemonJson["Trigger"] as JArray;
                List<EvolutionTrigger> evolutionTriggers = new List<EvolutionTrigger>();
                foreach (var trigger in (triggers).Values())
                {
                    evolutionTriggers.Add((EvolutionTrigger)Enum.Parse(typeof(EvolutionTrigger), trigger.ToString()));
                }

                return evolutionTriggers;
            }
        }

        public string Description => _pokemonJson["Description"].ToString();

        public PokemonInfo(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            {
                Sprites = new Image[4];
                var resourceStream = assembly.GetManifestResourceStream($"OpenPokeLib.Resources.Pokemon.{name}.json");

                //Load up our Pokemon json
                using (StreamReader file = new StreamReader(resourceStream))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        _pokemonJson = (JObject) JToken.ReadFrom(reader);    
                    }
                }

                var num = _pokemonJson["Number"]?.ToString().PadLeft(3,'0');
                
                //Streams for sprites
                var spriteFrontStream = assembly.GetManifestResourceStream($"OpenPokeLib.Resources.Sprites.Spr_4d_{num}.png");
                var spriteFrontShinyStream = assembly.GetManifestResourceStream($"OpenPokeLib.Resources.Sprites.Spr_4d_{num}_s.png");
                var spriteBackStream = assembly.GetManifestResourceStream($"OpenPokeLib.Resources.Sprites.Spr_b_4d_{num}.png");
                var spriteBackShinyStream = assembly.GetManifestResourceStream($"OpenPokeLib.Resources.Sprites.Spr_b_4d_{num}.png");

                try //Let's try to set all of our sprite images from the streams
                {
                    Sprites[0] = Bitmap.FromStream(spriteFrontStream!);
                    Sprites[1] = Bitmap.FromStream(spriteBackStream!);
                    Sprites[2] = Bitmap.FromStream(spriteFrontShinyStream!);
                    Sprites[3] = Bitmap.FromStream(spriteBackShinyStream!);
                }
                catch (Exception e) //Handle the Pokemon even if the sprite image is missing
                {
                    Console.WriteLine("Missing sprite for " + name);
                    spriteFrontStream = assembly.GetManifestResourceStream($"OpenPokeLib.Resources.Sprites.Missingno_F.png");
                    spriteBackStream = assembly.GetManifestResourceStream("OpenPokeLib.Resources.Sprites.Missingno_B.png");
                    Sprites[0] = Bitmap.FromStream(spriteFrontStream!);
                    Sprites[1] = Bitmap.FromStream(spriteBackStream!);
                    Sprites[2] = Bitmap.FromStream(spriteFrontStream!);
                    Sprites[3] = Bitmap.FromStream(spriteBackStream!);
                }
                
                resourceStream.Close();
                spriteFrontStream.Close();
                spriteBackStream.Close();
                if (spriteFrontShinyStream != null) spriteFrontShinyStream.Close();
                if (spriteBackShinyStream != null) spriteBackShinyStream.Close();
            }
        }

        public Ability GetAbility(int num)
        {
            var ab = _pokemonJson["Abilities"]?[num];
            var ability = Activator.CreateInstance(Type.GetType("OpenPokeLib.Abilities" + "." + ab.ToString().Replace("_","")) ?? typeof(Blaze)) as Ability;
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