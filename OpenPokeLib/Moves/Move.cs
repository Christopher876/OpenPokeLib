using System;

namespace OpenPokeLib.Moves
{
    public class Move
    {
        public string Name;
        public Types Type;
        public int PP;
        public int MaxPP;
        public int Power;
        public int Accuracy;
        public bool IsStatus;
        public Tuple<Effects,int> OtherEffect; //Chance for the move to cause an additional Effect such as burn or freeze
    }
}