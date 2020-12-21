namespace OpenPokeLib
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Exp { get; set; }
        public PokemonStats Stats { get; set; }
        public Move[] Moves;
    }
}