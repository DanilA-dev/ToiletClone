using System;
using UniRx;
using UnityEngine;

namespace Systems
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private int _health;

        public event Action OnDie;
        
        public int CurrentHealth { get; set; }
        public bool IsDead { get; private set; }

        private void Awake()
        {
            CurrentHealth = _health;
        }

        public void Damage(int damageValue)
        {
            CurrentHealth -= damageValue;
            if (CurrentHealth <= 0)
                Die();
        }

        private void Die()
        {
            IsDead = true;
            OnDie?.Invoke();
        }
    }
}