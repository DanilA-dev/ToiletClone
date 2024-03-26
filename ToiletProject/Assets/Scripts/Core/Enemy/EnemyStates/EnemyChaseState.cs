using Core.Interfaces;
using UnityEngine.AI;

namespace Core.Enemy.EnemyStates
{
    public class EnemyChaseState : BaseEnemyState
    {
        private ITarget _target;
        private readonly EnemyChaseSerializeData _serializeData;
        private readonly NavMeshAgent _agent;
        
        public EnemyChaseState(EnemyController enemyController, EnemyChaseSerializeData serializeData,
            EnemyView view) : base(enemyController, view)
        {
            _serializeData = serializeData;
            _agent = enemyController.Agent;
        }

        public override void OnEnter()
        {
           _view.Move();
           _agent.speed = _serializeData.Speed;
           _agent.enabled = true;
           _agent.updateRotation = true;
        }

        public void SetTarget(ITarget target) => _target = target;
        
        public override void OnUpdate()
        {
            _agent.destination = _target.Transform.position;
        }

        public override void OnExit()
        {
            _agent.isStopped = true;
            _agent.updateRotation = false;
            _agent.enabled = false;
        }
        
        public override string ToString()
        {
            return "Chase";
        }
    }
}