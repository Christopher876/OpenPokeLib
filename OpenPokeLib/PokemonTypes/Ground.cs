namespace OpenPokeLib.PokemonTypes
{
    public class Ground : IPokemonType
    {
        public string Name => "Ground";

        public Types[] SuperEffective
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

        public Types[] NotEffective
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
    }
}