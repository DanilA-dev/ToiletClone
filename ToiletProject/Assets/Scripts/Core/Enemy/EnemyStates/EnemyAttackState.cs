using System.Collections.Generic;
using Systems;
using Core.Player;
using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    public class EnemyAttackState : BaseEnemyState
    {
        private EnemyAttackSerializeData _data;
        private CountdownTimer _attackDelayTimer;
        private CountdownTimer _attackTimer;
        private CountdownTimer _attackCooldownTimer;

        private List<BaseTimer> _timers;
        private HealthSystem _playerHealth;
        
        public EnemyAttackState(PlayerController playerController, EnemyAttackSerializeData data) : base(playerController)
        {
            _data = data;
            _playerHealth = _player.HealthSystem;
        }

        public override void OnEnter()
        {
            Debug.Log("Enter Attack state");
            
            var delayTime = Random.Range(_data.MinBeforeAttackTime, _data.MaxBeforeAttackTime);
            var cooldownn = Random.Range(_data.MinAttackTCooldown, _data.MaxnAttackTCooldown);
            _attackDelayTimer = new CountdownTimer(delayTime);
            _attackCooldownTimer = new CountdownTimer(cooldownn);
            _attackTimer = new CountdownTimer(_data.AttackTime);
            
            _attackDelayTimer.Start();
            _attackDelayTimer.OnTimerEnd += Attack;
            
            _timers = new List<BaseTimer>
            {
                _attackTimer,
                _attackCooldownTimer,
                _attackDelayTimer
            };
        }

        private void Attack()
        {
            _attackTimer.Start();
            _playerHealth.Damage(_data.Damage);
            _attackTimer.OnTimerEnd += Cooldown;
        }

        private void Cooldown()
        {
            _attackCooldownTimer.Start();
            _attackCooldownTimer.OnTimerEnd += Attack;
        }

        public override void OnUpdate()
        {
            foreach (var timer in _timers)
                timer.Tick(Time.deltaTime);

            RotateTowardsPlayer();
        }

        private void RotateTowardsPlayer()
        {
            var dir = _player.transform.position - _data.EnemyTransform.position;
            var rotSpeed = _data.RotateSpeed * Time.deltaTime;
            Quaternion lookTowards = Quaternion.LookRotation(dir.normalized);
            _data.EnemyTransform.rotation = Quaternion.RotateTowards(_data.EnemyTransform.rotation, lookTowards, rotSpeed);
        }

        public override void OnExit()
        {
            Debug.Log("Exit Attack state");
            
            foreach (var timer in _timers)
                timer.Stop();
        }
    }
}