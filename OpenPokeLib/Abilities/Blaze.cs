namespace OpenPokeLib.Abilities
{
    public class Blaze : Ability
    {
        public override string Name { get; set; }

        public Blaze()
        {
            Name = "Blaze";
        }

        public override object BeforeTurn()
        {
            return 0.5f;
        }
    }
}