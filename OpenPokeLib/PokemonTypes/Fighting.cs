namespace OpenPokeLib.PokemonTypes
{
    public class Fighting : IPokemonType
    {
        public Fighting() : base("Fighting")
        {
        }

        public override Types[] SuperEffective { get; }
        public override Types[] NotEffective { get; }
    }
}