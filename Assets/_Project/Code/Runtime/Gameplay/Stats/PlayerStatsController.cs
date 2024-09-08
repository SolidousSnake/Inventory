using System;
using _Project.Code.Runtime.UI.View;
using UniRx;

namespace _Project.Code.Runtime.Gameplay.Stats
{
    public class PlayerStatsController : IDisposable
    {
        private readonly PlayerStats _playerStats;
        private readonly StatsView _statsView;
        private readonly CompositeDisposable _compositeDisposable;

        public PlayerStatsController(PlayerStats playerStats, StatsView statsView)
        {
            _playerStats = playerStats;
            _statsView = statsView;
            _compositeDisposable = new CompositeDisposable();
        }

        public void Initialize()
        {
            _playerStats.Strength.Subscribe(value => _statsView.SetAmountStrengthLabel(value)).AddTo(_compositeDisposable);
            _playerStats.Stamina.Subscribe(value => _statsView.SetAmountStaminaLabel(value)).AddTo(_compositeDisposable);
            _playerStats.Wisdom.Subscribe(value => _statsView.SetAmountWisdomLabel(value)).AddTo(_compositeDisposable);
        }

        public void SetStrength(float value) => _playerStats.Strength.Value = value;
        public void SetStamina(float value) => _playerStats.Stamina.Value = value;
        public void SetWisdom(float value) => _playerStats.Wisdom.Value = value;

        public void Dispose() => _compositeDisposable.Clear();
    }
}