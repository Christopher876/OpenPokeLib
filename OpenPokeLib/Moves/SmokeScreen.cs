namespace OpenPokeLib.Moves
{
    public class SmokeScreen : Move
    {
        public SmokeScreen()
        {
            Name = "Smokescreen";
            Type = Types.Normal;
            PP = 40;
            MaxPP = 40;
            Power = 0;
            Accuracy = 100;
            IsStatus = true;
        }
    }
}