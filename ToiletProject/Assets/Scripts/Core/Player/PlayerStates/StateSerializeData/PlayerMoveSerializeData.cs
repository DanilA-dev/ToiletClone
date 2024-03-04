using UnityEngine;
using UnityEngine.AI;

namespace Core.Player.PlayerStates.StateSerializeData
{
    [System.Serializable]
    public class PlayerMoveSerializeData
    {
        [field: SerializeField] public NavMeshAgent Agent { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float StopDistance { get; private set; }
    }
}