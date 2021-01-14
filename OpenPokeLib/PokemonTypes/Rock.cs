namespace OpenPokeLib.PokemonTypes
{
    public class Rock : IPokemonType
    {
        public override Types[] SuperEffective { get; }
        public override Types[] NotEffective { get; }

        public Rock() : base("Rock")
        {
        }
    }
}