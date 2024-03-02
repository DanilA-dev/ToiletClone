﻿using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    [System.Serializable]
    public class EnemyAttackSerializeData
    {
        [field: SerializeField] public Transform EnemyTransform { get; private set; }
        [field: SerializeField] public float RotateSpeed { get; private set; }
        [field: SerializeField] public float MinBeforeAttackTime { get; private set; }
        [field: SerializeField] public float MaxBeforeAttackTime { get; private set; }
        [field: SerializeField] public float AttackTime { get; private set; }
        [field: SerializeField] public float MinAttackTCooldown { get; private set; }
        [field: SerializeField] public float MaxnAttackTCooldown { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
    }
}