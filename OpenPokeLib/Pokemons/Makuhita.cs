using OpenPokeLib.Experience;

namespace OpenPokeLib.Pokemons
{
    public class Makuhita : Pokemon
    {
        public Makuhita(Nature nature, int[] ivs, int[] evs) : base(nature, ivs, evs)
        {
            Name = "Makuhita";
            Stats.SetBaseStats(72,60,30,20,30,25);
            Stats.Experience = new Fluctuating();
        }
    }
}