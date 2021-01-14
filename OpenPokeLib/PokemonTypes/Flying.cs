namespace OpenPokeLib.PokemonTypes
{
    public class Flying : IPokemonType
    {
        public override Types[] SuperEffective { get; }
        public override Types[] NotEffective { get; }

        public Flying() : base("Flying")
        {
        }
    }
}