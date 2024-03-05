using System;
using UniRx;
using UnityEngine;

namespace Systems
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private int _health;

        public event Action OnDie;
        public event Action<float, float> OnHealhChange;
        
        public int CurrentHealth { get; private set; }
        public bool IsDead { get; private set; }
        public bool IsDamagable { get; private set; }

        private void Awake()
        {
            CurrentHealth = _health;
        }

        public void Damage(int damageValue)
        {
            if(!IsDamagable)
                return;
            
            CurrentHealth -= damageValue;
            OnHealhChange?.Invoke(CurrentHealth, _health);
            if (CurrentHealth <= 0)
                Die();
        }
        
        public void SetDamagable(bool value) => IsDamagable = value;

        public void SetMaxHealth(int maxHealth)
        {
            _health = maxHealth;
            CurrentHealth = _health;
        }

        private void Die()
        {
            IsDead = true;
            OnDie?.Invoke();
        }
    }
}