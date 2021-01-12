namespace OpenPokeLib.PokemonTypes
{
    public class Rock : IPokemonType
    {
        public string Name => "Rock";
        public Types[] SuperEffective { get; }
        public Types[] NotEffective { get; }
    }
}