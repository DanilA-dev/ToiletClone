using Systems;
using CustomFSM.State;
using Entity;
using UnityEngine;

namespace Core.Player
{
    public class PlayerController : BaseFSMActor
    {
        [SerializeField] private HealthSystem _healthSystem;
        
        public override IState StartState { get; }

        public HealthSystem HealthSystem => _healthSystem;

        protected override void InitStatesAndTransitions()
        {
            
        }
    }
}