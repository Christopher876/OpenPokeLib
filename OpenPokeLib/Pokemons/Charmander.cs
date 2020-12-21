using OpenPokeLib;

namespace OpenPokeLib.Pokemons
{
    public class Charmander : Pokemon
    {
        public Charmander()
        {
            Name = "Charmander";
            NickName = "Charmander";
            Level = 5;
            
            Stats.SetBaseStats(39,52,43,60,50,65);
        }
    }
}