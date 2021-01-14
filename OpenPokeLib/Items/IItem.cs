namespace OpenPokeLib.Items
{
    public interface IItem
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }
        public BagSections Section { get; set; }
        public string Description { get; set; }
        public void PokemonEffect();
        public void OverworldEffect();
    }
}