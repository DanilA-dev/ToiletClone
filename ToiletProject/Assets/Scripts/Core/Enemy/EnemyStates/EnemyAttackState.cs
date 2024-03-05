using Core.Player;
using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    public class EnemyAttackState : BaseEnemyState
    {
        private EnemyAttackSerializeData _data;
        
        public EnemyAttackState(PlayerController playerController, EnemyAttackSerializeData data,
            EnemyView view) : base(playerController, view)
        {
            _data = data;
        }

        public override void OnEnter()
        {
            Debug.Log("Enter Attack state");
            _view.Attack();
        }
       
        public override void OnUpdate()
        {
            RotateTowardsPlayer();
        }

        private void RotateTowardsPlayer()
        {
            var rotSpeed = _data.RotateSpeed * Time.deltaTime;
            _data.EnemyTransform.RotateTowardsByAxis(_player.transform, Vector3.up, rotSpeed);
        }

        public override void OnExit()
        {
            Debug.Log("Exit Attack state");
        }
    }
}