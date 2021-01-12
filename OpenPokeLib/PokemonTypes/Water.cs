namespace OpenPokeLib.PokemonTypes
{
    public class Water : IPokemonType
    {
        public string Name => "Water";
        public Types[] SuperEffective { get; }
        public Types[] NotEffective { get; }
    }
}