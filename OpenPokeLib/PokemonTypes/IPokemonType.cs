namespace OpenPokeLib.PokemonTypes
{
    public abstract class IPokemonType
    {
        protected IPokemonType(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public abstract Types[] SuperEffective { get; }
        public abstract Types[] NotEffective { get; }
        public override string ToString()
        {
            return Name;
        }
    }
}