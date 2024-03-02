using Core.Player;
using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    public class EnemyChaseState : BaseEnemyState
    {
        private EnemyChaseSerializeData _serializeData;
        
        public EnemyChaseState(PlayerController playerController, EnemyChaseSerializeData serializeData) : base(playerController)
        {
            _serializeData = serializeData;
        }

        public override void OnEnter()
        {
           Debug.Log("Enter chase state");
           _serializeData.Agent.isStopped = false;
           _serializeData.Agent.enabled = true;
           _serializeData.Agent.updateRotation = true;
           _serializeData.Agent.destination = _player.transform.position;
        }

        public override void OnExit()
        {
            Debug.Log("Exit chase state");
            _serializeData.Agent.isStopped = true;
            _serializeData.Agent.updateRotation = false;
            _serializeData.Agent.enabled = false;
        }
    }
}