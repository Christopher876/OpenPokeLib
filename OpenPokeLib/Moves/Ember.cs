using System;

namespace OpenPokeLib.Moves
{
    public class Ember : Move
    {
        public Ember()
        {
            Name = "Ember";
            Type = Types.Fire;
            PP = 40;
            MaxPP = 40;
            Power = 40;
            Accuracy = 100;
            OtherEffect = new Tuple<Effects, int>(Effects.Burned,10);
        }
    }
}