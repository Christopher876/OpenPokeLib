using OpenPokeLib.Experience;

namespace OpenPokeLib.Pokemons
{
    public class Makuhita : Pokemon
    {
        public Makuhita() : base("Makuhita")
        {
            Stats.Experience = new Fluctuating();
        }
    }
}