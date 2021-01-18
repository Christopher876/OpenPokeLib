using System;
using System.Diagnostics;

namespace OpenPokeLib.Battle
{
    public class BattleManager
    {
        private readonly bool _isTrainer;
        private Trainer Opponent;

        private Pokemon CurrentPlayerPokemon;
        private Pokemon CurrentOpponentPokemon;

        public BattleManager(bool isTrainer, Pokemon WildPokemon = null)
        {
            _isTrainer = isTrainer;
            if (WildPokemon != null)
            {
                CurrentOpponentPokemon = WildPokemon;
            }
        }

        public void SwitchPokemon(int slot)
        {
            CurrentPlayerPokemon = GlobalObjectManager.instance.Player.Team[slot];
            Debug.WriteLine($"Switched to {CurrentPlayerPokemon}");
        }

        public void SetCurrentActivePlayerPokemon(int slot)
        {
            //TODO Check if that Pokemon exists in the slot
            CurrentPlayerPokemon = GlobalObjectManager.instance.Player.Team[slot];
            Debug.WriteLine($"Player Pokemon set to {CurrentPlayerPokemon}");
        }

        public void SetCurrentActiveOpponentPokemon(int slot)
        {
            CurrentOpponentPokemon = Opponent.Team[slot];
            Debug.WriteLine($"Opponent Pokemon set to {CurrentPlayerPokemon}");
        }

        public void DefeatPokemon()
        {
            var gainedExp = ExperienceCalculation.CalculateExp(GlobalObjectManager.instance.Player, CurrentPlayerPokemon, CurrentOpponentPokemon, _isTrainer);
            CurrentPlayerPokemon.GainExp(gainedExp);
        }
    }
}