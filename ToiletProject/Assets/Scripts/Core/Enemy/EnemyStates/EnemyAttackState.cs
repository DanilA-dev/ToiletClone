using Core.Interfaces;
using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    public class EnemyAttackState : BaseEnemyState
    {
        private readonly EnemyAttackSerializeData _data;
        private ITarget _target;

        public EnemyAttackState(EnemyController enemyController, EnemyAttackSerializeData data,
            EnemyView view) : base(enemyController, view)
        {
            _data = data;
        }

        public void SetTarget(ITarget target) => _target = target;
        
        public override void OnEnter()
        {
        }
       
        public override void OnUpdate()
        {
            RotateTowardsTarget();
        }

        private void RotateTowardsTarget()
        {
            var rotSpeed = _data.RotateSpeed * Time.deltaTime;
            _enemyController.transform.LookAt(_target.Transform);
        }

        public override void OnExit()
        {
        }

        public override string ToString()
        {
            return "Attack";
        }
    }
}