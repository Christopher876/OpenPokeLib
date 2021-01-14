namespace OpenPokeLib.PokemonTypes
{
    public class Ground : IPokemonType
    {
        public override Types[] SuperEffective
        {
            get
            {
                return new[]
                {
                    Types.Fire,
                    Types.Rock,
                    Types.Electric,
                    Types.Poison,
                    Types.Steel
                };
            }
        }

        public override Types[] NotEffective
        {
            get
            {
                return new[]
                {
                    Types.Poison,
                    Types.Rock
                };
            }
        }

        public Ground() : base("Ground")
        {
        }
    }
}