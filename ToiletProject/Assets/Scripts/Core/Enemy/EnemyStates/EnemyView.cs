using System;
using Systems;
using DG.Tweening;
using UnityEngine;

namespace Core.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _shakeDelay;
        [SerializeField] private float _shakeStrength;
        [SerializeField] private float _shakeDuration;

        private string _moveAnim = "Walk";
        private string _idleAnim = "Idle";
        private string _attackAnim = "Attack2";
        private string _dieAnim = "Death";

        private void Start()
        {
            _healthSystem.OnHealhChange += OnDamaged;
        }

        private void OnDestroy()
        {
            _healthSystem.OnHealhChange -= OnDamaged;
        }

        private void OnDamaged(float arg1, float arg2)
        {
            var seq = DOTween.Sequence();
            seq.Restart();
            seq.AppendInterval(_shakeDelay);
            seq.Append(transform.DOShakeScale(_shakeDuration, _shakeStrength));
        }

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