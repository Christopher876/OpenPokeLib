using OpenPokeLib.Experience;

namespace OpenPokeLib.Pokemons
{
    public class Squirtle : Pokemon
    {
        public Squirtle() : base("Squirtle")
        {
            Name = "Squirtle";
            Stats.Experience = new MediumSlow();
        }
    }
}