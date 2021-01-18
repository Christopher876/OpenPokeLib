using System;

namespace OpenPokeLib.Battle
{
    public class ExperienceCalculation
    {
        public static int CalculateExp(Trainer player, Pokemon playerCurrent, Pokemon opponent, bool isTrainer)
        {
            var a = isTrainer ? 1.5f : 1;
            var b = opponent.Info.BaseExperienceYield;
            var e = (playerCurrent.HeldItem.Name == "Lucky Egg") ? 1.5f:1f;
            var f = 1; //TODO implement affection for the generation V+ https://bulbapedia.bulbagarden.net/wiki/Affection
            var L = opponent.Stats.Level;
            var Lp = playerCurrent.Stats.Level;
            var p = 1; //TODO implement Exp. Point Power, i.e. Pass Power, O-Power ; Default to 1 for now
            
            //Exp Share
            //TODO Potentially needs to be fixed if it isn't being calculated correctly https://bulbapedia.bulbagarden.net/wiki/Experience#Experience_gain_in_battle
            var s = 1;
            foreach (var pokemon in player.Team)
            {
                if (pokemon.HeldItem.Name == "Exp Share")
                    s++;
            }

            var t = 1f;
            //Original Trainer Resolve
            if (playerCurrent.OGTrainerID != player.TrainerId && playerCurrent.OGTrainerCountry != player.HomeCountry)
                t = 1.7f;
            else if (playerCurrent.OGTrainerID != player.TrainerId)
                t = 1.5f;

            var v = 1; //TODO possibly do not implement this ; Generation VI+ more exp if pokemon is past evolution level
            
            var exp = (((a * b * L) / (5 * s)) * (Math.Pow(2*L+10,2.5) / Math.Pow(L+Lp+10,2.5)) + 1) * t * e * p; //Generation 5 scaled formula

            return (int) Math.Floor(exp);
        }
    }
}