namespace OpenPokeLib.PokemonTypes
{
    public class Water : IPokemonType
    {
        public override Types[] SuperEffective { get; }
        public override Types[] NotEffective { get; }

        public Water() : base("Water")
        {
        }
    }
}