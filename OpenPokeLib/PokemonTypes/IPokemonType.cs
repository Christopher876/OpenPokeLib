namespace OpenPokeLib.PokemonTypes
{
    public interface IPokemonType
    {
        public string Name { get; }
        public Types[] SuperEffective { get; }
        public Types[] NotEffective { get; }
    }
}