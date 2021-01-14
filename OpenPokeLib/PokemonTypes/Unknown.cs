namespace OpenPokeLib.PokemonTypes
{
    public class Unknown : IPokemonType
    {
        public override Types[] SuperEffective { get; }
        public override Types[] NotEffective { get; }

        public Unknown() : base("Unknown")
        {
        }
    }
}