using System;

namespace OpenPokeLib.Items
{
    public class Potion : Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Potion(string name) : base(name){}

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