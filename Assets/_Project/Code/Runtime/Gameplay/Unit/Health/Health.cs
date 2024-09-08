using System;
using UniRx;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.Unit.Health
{
    public class Health : MonoBehaviour
    {
        public float MaxHealth { get; private set; }
        
        private readonly ReactiveProperty<float> _health = new ReactiveProperty<float>();
        public IReadOnlyReactiveProperty<float> CurrentHealth => _health;

        public event Action Depleted;

        public void Initialize(float health)
        {
            if (health < 0)
                throw new ArgumentException($"Health value must be positive. Received: {health}");

            _health.Value = MaxHealth = health;
        }
        
        public void ApplyDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentException($"Damage value must be positive. Received: {damage}");

            _health.Value -= damage;

            if (_health.Value <= 0)
            {
                _health.Value = 0;
                Depleted?.Invoke();
            }
        }

        public void ApplyHeal(float health)
        {
            if (health < 0)
                throw new ArgumentException($"Healing value must be positive. Received: {health}");

            _health.Value += health;

            if (_health.Value > MaxHealth)
                _health.Value = MaxHealth;
        }

        public void ResetHealth() => ApplyHeal(MaxHealth);
    }
}