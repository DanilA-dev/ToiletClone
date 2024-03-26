using Core.Interfaces;
using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    public class EnemyCombatState : BaseEnemyState
    {
        private ITarget _player;
        
        public EnemyCombatState(EnemyController enemyController, EnemyView view) 
            : base(enemyController, view)
        {
        }

        public void SetTarget(ITarget player) => _player = player;
        
        public override void OnEnter()
        {
            _enemyController.EnterCombat();
            _view.Idle();
        }

        public override void OnUpdate()
        {
            RotaeTowardsPlayer();
        }

        private void RotaeTowardsPlayer()
        {
            if(_player == null)
                return;
            
            _enemyController.transform.RotateTowardsByAxis(_player.Transform, Vector3.up,_enemyController.RotationSpeed);
        }


        public override void OnExit()
        {
        }
        
        public override string ToString()
        {
            return "Combat";
        }
    }
}