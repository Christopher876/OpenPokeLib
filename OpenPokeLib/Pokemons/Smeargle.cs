using OpenPokeLib.Experience;

namespace OpenPokeLib.Pokemons
{
    public class Smeargle : Pokemon
    {
        public Smeargle() : base()
        {
            Name = "Smeargle";
            Stats.SetBaseStats(108,130,95,80,85,102);
        }

        public Smeargle(Nature nature, int[] ivs, int[] evs) : base(nature, ivs, evs)
        {
            Name = "Smeargle";
            Stats.SetBaseStats(55,20,35,20,45,75);
            Stats.Experience = new Fast();
        }
    }
}