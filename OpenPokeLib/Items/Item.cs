using System;

namespace OpenPokeLib.Items
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Item(string name)
        {
            var info = Utils.GetItemInfo.ReadInfo($"Resources/Items/{name}.txt");
            Name = info.Item1;
            Description = info.Item2;
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