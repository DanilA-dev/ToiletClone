using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _damage;

        public int MaxHealth => _maxHealth;
        public int Damage => _damage;

        public void IncreaseDamage() => _damage++;
        public void IncreaseMaxHealth() => _maxHealth++;
        public void SetDamage(int newDamage) => _damage = newDamage;
        public void SetMaxHealth(int newHealth) => _maxHealth = newHealth;
    }

}
