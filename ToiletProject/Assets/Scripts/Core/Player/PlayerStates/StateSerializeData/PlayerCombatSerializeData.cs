using UnityEngine;

namespace Core.Player.PlayerStates
{
    [System.Serializable]
    public class PlayerCombatSerializeData
    {
        [field: SerializeField] public float RotateSpeed { get; private set; }
    }
}