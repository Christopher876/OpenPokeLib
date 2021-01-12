namespace OpenPokeLib.PokemonTypes
{
    public class Fire : IPokemonType
    {
        public string Name => "Fire";

        public Types[] SuperEffective
        {
            get
            {
                return new[]
                {
                    Types.Water,
                    Types.Rock,
                    Types.Ground
                };
            }
        }

        public Types[] NotEffective
        {
            get
            {
                return new[]
                {
                    Types.Bug,
                    Types.Steel,
                    Types.Fire,
                    Types.Grass,
                    Types.Ice,
                    Types.Fairy
                };
            }
        }
    }
}