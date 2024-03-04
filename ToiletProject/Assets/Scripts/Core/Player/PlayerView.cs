using UnityEngine;

namespace Core.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private int _moveHash = Animator.StringToHash("Move");
        private int _idleHash = Animator.StringToHash("Idle");
        private int _attackHash = Animator.StringToHash("Attack");
        private int _blockHash = Animator.StringToHash("Block");
        private int _dieHash = Animator.StringToHash("Die");

        public void Move()
        {
            
        }

        public void Idle()
        {
            
        }

        public void Attack()
        {
            
        }
        
        public void Block()
        {
            
        }
        
        public void Die()
        {
            
        }
    }
}