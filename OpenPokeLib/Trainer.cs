using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenPokeLib
{
    public class Trainer
    {
        public Pokemon[] Team;
        public ushort TrainerId;
        public ushort SecretId;

        public Trainer(IEnumerable<Pokemon> team)
        {
            Team = team as Pokemon[];
        }

        public void GenerateTrainerId()
        {
            Random random = new Random();
            TrainerId = Convert.ToUInt16(random.Next(65_536));
            SecretId = Convert.ToUInt16(random.Next(65_536));
        }
    }
}