using System;
using System.IO;
using System.Reflection;

namespace OpenPokeLib.Items
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }
        public BagSections Section { get; set; }
        public string Description { get; set; }
        public Item(string name)
        {
            // var assembly = Assembly.GetExecutingAssembly();
            // var resourceStream = assembly.GetManifestResourceStream($"OpenPokeLib.Resources.Items.{name}.txt");
            // Tuple<string, string> item;
            // using (StreamReader reader = new StreamReader(resourceStream))
            // {
            //     var r = reader.ReadToEnd();
            // }
            
            //var info = Utils.GetItemInfo.ReadInfo($"Resources/Items/{name}.txt");
            // Name = info.Item1;
            // Description = info.Item2;
        }

        public void PokemonEffect()
        {
            throw new System.NotImplementedException();
        }

        public void OverworldEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}