namespace OpenPokeLib.Items
{
    public interface IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public void PokemonEffect();
        public void OverworldEffect();
    }
}