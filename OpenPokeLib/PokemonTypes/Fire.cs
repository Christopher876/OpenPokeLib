namespace OpenPokeLib.PokemonTypes
{
    public class Fire : IPokemonType
    {
        public override Types[] SuperEffective
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

        public override Types[] NotEffective
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

        public Fire() : base("Fire")
        {
        }
    }
}