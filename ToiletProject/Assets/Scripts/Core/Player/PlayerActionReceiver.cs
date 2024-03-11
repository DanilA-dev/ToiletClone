using System;
using UniRx;
using UnityEngine;

namespace Core.Player
{
    public class PlayerActionReceiver : MonoBehaviour
    {
        [SerializeField] private bool _isAttacking;
        [SerializeField] private bool _isBlocking;
        [SerializeField] private float _attackCooldown;

        private CountdownTimer _coolDownTimer;
        
        public Action OnAttackStartAction;
        public Action OnAttackEndAction;
        public bool IsBlocking => _isBlocking;
        public bool IsAttacking => _isAttacking;

        private void Awake()
        {
            MessageBroker.Default.Receive<PlayerCoreAction>()
                .Where(a => a.PlayerCoreActionType == PlayerCoreActionType.Attack)
                .Subscribe(s => AttackSignalInvoke()).AddTo(gameObject);
            
            MessageBroker.Default.Receive<PlayerCoreAction>()
                .Where(a => a.PlayerCoreActionType == PlayerCoreActionType.Block)
                .Subscribe(s => BlockSignalInvoke()).AddTo(gameObject);
            
            MessageBroker.Default.Receive<PlayerCoreAction>()
                .Where(a => a.PlayerCoreActionType == PlayerCoreActionType.None)
                .Subscribe(s => NoActionSignalInvoke()).AddTo(gameObject);
            
            _coolDownTimer = new CountdownTimer(_attackCooldown);
        }

        private void Update()
        {
            _coolDownTimer.Tick(Time.deltaTime);
        }

        private void AttackSignalInvoke()
        {
            if(_isAttacking)
                return;
            
            _isAttacking = true;
            OnAttackStartAction?.Invoke();
            _coolDownTimer.Start();
            _coolDownTimer.OnTimerEnd += AttackEnd;
        }

        private void AttackEnd()
        {
            _isAttacking = false;
            OnAttackEndAction?.Invoke();
            _coolDownTimer.OnTimerEnd -= AttackEnd;
        }

        private void BlockSignalInvoke()
        {
            _isBlocking = true;
        }
        
        private void NoActionSignalInvoke()
        {
            _isBlocking = false;
        }


    }
}