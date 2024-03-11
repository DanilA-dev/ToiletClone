using Core.Player;
using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    public class EnemyChaseState : BaseEnemyState
    {
        private EnemyChaseSerializeData _serializeData;
        
        public EnemyChaseState(PlayerController playerController, EnemyChaseSerializeData serializeData,
            EnemyView view) : base(playerController, view)
        {
            _serializeData = serializeData;
        }

        public override void OnEnter()
        {
           _view.Move();
           _serializeData.Agent.speed = _serializeData.Speed;
           _serializeData.Agent.enabled = true;
           _serializeData.Agent.updateRotation = true;
        }

        public override void OnUpdate()
        {
            _serializeData.Agent.destination = _player.transform.position;
        }

        public override void OnExit()
        {
            _serializeData.Agent.isStopped = true;
            _serializeData.Agent.updateRotation = false;
            _serializeData.Agent.enabled = false;
        }
    }
}