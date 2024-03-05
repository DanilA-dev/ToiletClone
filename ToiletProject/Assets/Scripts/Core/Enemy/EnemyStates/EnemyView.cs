using UnityEngine;

namespace Core.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private string _moveAnim = "Walk";
        private string _idleAnim = "Idle";
        private string _attackAnim = "Attack2";
        private string _dieAnim = "Die";

        public void Move()
        {
            _animator.CrossFade(_moveAnim, 0.1f);
        }

        public void Idle()
        {
            _animator.CrossFade(_idleAnim, 0.1f);
        }

        public void Attack()
        {
            _animator.CrossFade(_attackAnim, 0);
        }

        public void Die()
        {
            _animator.CrossFade(_dieAnim, 0.1f);
        }
    }
}