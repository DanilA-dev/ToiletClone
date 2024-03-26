using CustomFSM.Preicate;
using CustomFSM.State;
using CustomFSM.StateMachine;
using UnityEngine;

namespace Entity
{
    public abstract class BaseFSMActor : Entity
    {
        [SerializeField] private bool _addDebugger;
        
        protected StateMachine _stateMachine;
        
        public abstract IState StartState { get; }
        public StateMachine StateMachine => _stateMachine;

        protected virtual void Update()
        {
            _stateMachine?.OnUpdate();
        }

        protected void InitStateMachine()
        {
            _stateMachine = new StateMachine();

            if (_addDebugger)
                gameObject.AddComponent<StateMachineDebugger>();
        }

        protected void AddTransition(IState from, IState to, IPredicate condition) =>
            _stateMachine.AddTransition(from, to, condition);

        protected void AddAnyTransition(IState to, IPredicate condition) => 
            _stateMachine.AddAnyTransition(to, condition);

        protected abstract void InitStatesAndTransitions();
    }
}