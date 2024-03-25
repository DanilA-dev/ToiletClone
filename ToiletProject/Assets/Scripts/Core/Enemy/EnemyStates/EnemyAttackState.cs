using Core.Interfaces;
using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    public class EnemyAttackState : BaseEnemyState
    {
        private readonly EnemyAttackSerializeData _data;
        
        public EnemyAttackState(EnemyController enemyController,ITarget target, EnemyAttackSerializeData data,
            EnemyView view) : base(enemyController,target, view)
        {
            _data = data;
        }

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
            _enemyController.transform.LookAt(Target.Transform);
        }

        public override void OnExit()
        {
        }
    }
}