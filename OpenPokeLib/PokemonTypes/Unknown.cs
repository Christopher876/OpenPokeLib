namespace OpenPokeLib.PokemonTypes
{
    public class Unknown : IPokemonType
    {
        public string Name => "Unknown";
        public Types[] SuperEffective { get; }
        public Types[] NotEffective { get; }
    }
}