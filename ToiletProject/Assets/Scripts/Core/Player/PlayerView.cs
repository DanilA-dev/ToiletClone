using System.Collections.Generic;
using UnityEngine;

namespace Core.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly string _runAnim = "Run";
        private readonly string _idleAnim = "Idle";
        private readonly string _combatIdleAnim = "CombatIdle";

        private readonly string _attack1Anim = "Attack_1";
        private readonly string _attack2Anim = "Attack_2";
        private readonly string _attack3Anim = "Attack_3";
        private readonly string _damagedAnim = "Hit";
        private readonly string _blockAnim = "Block";
        private readonly string _deathAnim = "Death";

        public void Run()
        {
            _animator.CrossFade(_runAnim, 0.1f);
        }

        public void Idle()
        {
            _animator.CrossFade(_idleAnim, 0.1f);
        }

        public void Attack()
        {
            List<string> anims =new List<string>
            {
                _attack1Anim,
                _attack2Anim,
                _attack3Anim
            };
            var attackAnim = anims[Random.Range(0, anims.Count)];
            _animator.CrossFade(attackAnim, 0);
        }

        public void Combat()
        {
            _animator.CrossFade(_combatIdleAnim, 0.1f);
        }
        
        public void Block()
        {
            _animator.CrossFade(_blockAnim, 0);
        }
        
        public void Die()
        {
            _animator.CrossFade(_deathAnim, 0.1f);
        }

        public void Damaged()
        {
            _animator.CrossFade(_damagedAnim, 0.1f);
        }
    }
}