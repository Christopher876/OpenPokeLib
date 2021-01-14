using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;

namespace OpenPokeLib.DataManager
{
    public class DataManager
    {
        private static JObject _dataJson = new JObject();
        private static readonly string Filename = "data.json";
        private static readonly string BsonFilename = "data.bson";
        
        public static void Setup()
        {
            //Open up the json file
            if (File.Exists(BsonFilename))
            {
                return;
            }
            else
            {
                using (File.Create(BsonFilename));
                //Setup the entire json file
                _dataJson = new JObject(
                    new JProperty("TrainerName"),
                    new JProperty("TrainerID"),
                    new JProperty("SecretID"),
                    new JProperty("Party",
                        new JArray()
                        ),
                    new JProperty("PC")
                );
            }
        }
        
        public static void SaveInitialInfo(Trainer trainer)
        {
            _dataJson["TrainerName"] = trainer.Name;
            _dataJson["TrainerID"] = trainer.TrainerId;
            _dataJson["SecretID"] = trainer.SecretId;
        }
        
        private static JArray CreatePokemonJson(IEnumerable<Pokemon> pokemons)
        {
            var j = new JArray(
                from pokemon in pokemons
                select new JObject(
                    new JProperty("Name",pokemon.Name),
                    new JProperty("Nickname", pokemon.NickName),
                    new JProperty("Shiny",pokemon.Shiny),
                    new JProperty("Health",pokemon.Health),
                    new JProperty("MaxHealth",pokemon.MaxHealth),
                    new JProperty("Exp",pokemon.Exp),
                    new JProperty("Moves",
                        //Save all of the moves of the pokemon
                        new JArray( from move in pokemon.Moves select new JObject(
                            new JProperty("Name",move.Name),
                            new JProperty("PP", move.PP),
                            new JProperty("MaxPP",move.MaxPP)
                        ))),
                    new JProperty("Effect",pokemon.Effect),
                    new JProperty("Gender", pokemon.Gender),
                    new JProperty("Level", pokemon.Stats.Level),
                    new JProperty("CurrentExp",pokemon.Stats.CurrentExp),
                    new JProperty("Nature",pokemon.Stats.Nature.ToString()),
                    new JProperty("IVs", new JArray( from iv in pokemon.Stats.IVs select new JValue(iv))),
                    new JProperty("EVs", new JArray(from ev in pokemon.Stats.EVs select new JValue(ev)))
                )
            );
            return j;
        }
        
        public static void Save(Trainer trainer, PC pc)
        {
            //Save the Pokemon in the Trainer's team
            _dataJson["Party"] = CreatePokemonJson(trainer.Team);
            
            //Save our PC Pokemon
            List<JArray> array = new List<JArray>(); 
            for (int i = 0; i < pc.MaxBoxCount; i++)
            {
                var boxPokemon = pc.RetrieveBox(i);
                array.Add(CreatePokemonJson(boxPokemon));
            }

            JObject p = new JObject();
            for (int i = 0; i < pc.MaxBoxCount; i++)
            {
                p.Add($"Box{i}",array[i]);
            }
            _dataJson["PC"] = p;
        }

        public static void Load()
        {
            //Load bson
            using (StreamReader reader = new StreamReader(BsonFilename))
            {
                var bsonFile = Convert.FromBase64String(reader.ReadToEnd());
                MemoryStream ms = new MemoryStream(bsonFile);
                using (BsonDataReader breader = new BsonDataReader(ms))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    _dataJson = serializer.Deserialize(breader) as JObject;
                }
            }
            Console.WriteLine(_dataJson);
        }

        public static Trainer LoadTrainer()
        {
            Trainer trainer = new Trainer();
            trainer.Name = _dataJson["TrainerName"].ToString();
            trainer.TrainerId = (ushort) _dataJson["TrainerID"];
            trainer.SecretId = (ushort) _dataJson["SecretID"];
            return trainer;
        }

        public static void Write()
        {
            //Write .bson
            MemoryStream ms = new MemoryStream();
            using (BsonDataWriter writer = new BsonDataWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer,_dataJson);
            }

            string data = Convert.ToBase64String(ms.ToArray());
            File.WriteAllText(BsonFilename,data);
            
            //Write .json
            using (StreamWriter file = File.CreateText(Filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _dataJson);
            }
        }
    }
}