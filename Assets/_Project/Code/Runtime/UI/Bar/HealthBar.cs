using _Project.Code.Runtime.Gameplay.Unit.Health;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Runtime.UI.Bar
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthFill;
        [SerializeField] private TextMeshProUGUI _healthLabel;

        private Health _health;

        public void Initialize(Health health)
        {
            _health = health;
            _health.CurrentHealth.Subscribe(SetHealthAmount).AddTo(this);
        }

        private void SetHealthAmount(float amount)
        {
            _healthLabel.text = $"{amount}HP";
            _healthFill.fillAmount = amount / _health.MaxHealth;
        }
    }
}