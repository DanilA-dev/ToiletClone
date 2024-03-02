using UnityEngine;

namespace Core.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private int _moveHash = Animator.StringToHash("Move");
        private int _idleHash = Animator.StringToHash("Idle");
        private int _attackHash = Animator.StringToHash("Attack");

        public void Move()
        {
            
        }

        public void Idle()
        {
            
        }

        public void Attack()
        {
            
        }
    }
}