using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    [System.Serializable]
    public class EnemyAttackSerializeData
    {
        [field: SerializeField] public float MinBeforeAttackTime { get; private set; }
        [field: SerializeField] public float MaxBeforeAttackTime { get; private set; }
        [field: SerializeField] public float AttackTime { get; private set; }
        [field: SerializeField] public float MinAttackCooldown { get; private set; }
        [field: SerializeField] public float MaxAttackCooldown { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
    }
}