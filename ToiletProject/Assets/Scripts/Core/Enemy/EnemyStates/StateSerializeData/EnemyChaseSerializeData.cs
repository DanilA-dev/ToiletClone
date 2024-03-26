using UnityEngine;
using UnityEngine.AI;

namespace Core.Enemy.EnemyStates
{
    [System.Serializable]
    public class EnemyChaseSerializeData
    {
        [field: SerializeField] public float Speed { get; private set; }
    }
}