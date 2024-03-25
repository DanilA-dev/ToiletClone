using Core.Interfaces;
using UnityEngine.AI;

namespace Core.Enemy.EnemyStates
{
    public class EnemyChaseState : BaseEnemyState
    {
        private readonly EnemyChaseSerializeData _serializeData;
        private readonly NavMeshAgent _agent;
        
        public EnemyChaseState(EnemyController enemyController,ITarget target, EnemyChaseSerializeData serializeData,
            EnemyView view) : base(enemyController,target, view)
        {
            _serializeData = serializeData;
            _agent = _serializeData.Agent;
        }

        public override void OnEnter()
        {
           _view.Move();
           _agent.speed = _serializeData.Speed;
           _agent.enabled = true;
           _agent.updateRotation = true;
        }

        public override void OnUpdate()
        {
            _agent.destination = Target.Transform.position;
        }

        public override void OnExit()
        {
            _agent.isStopped = true;
            _agent.updateRotation = false;
            _agent.enabled = false;
        }
    }
}