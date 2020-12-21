namespace OpenPokeLib.Moves
{
    public class Scratch : Move
    {
        public Scratch()
        {
            Name = "Scratch";
            Type = Types.Normal;
            PP = 40;
            MaxPP = 40;
            Power = 40;
            Accuracy = 100;
        }
    }
}