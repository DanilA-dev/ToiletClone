using System;
using CustomFSM.Preicate;
using CustomFSM.State;
using CustomFSM.StateMachine;

namespace Entity
{
    public abstract class BaseFSMActor : Entity
    {
        protected StateMachine _stateMachine;
        
        public abstract IState StartState { get; }

        private void Awake()
        {
            InitStateMachine();
            InitStatesAndTransitions();
        }

        private void Update()
        {
            _stateMachine?.OnUpdate();
        }

        private void InitStateMachine()
        {
            _stateMachine = new StateMachine();
        }

        protected void AddTransition(IState from, IState to, IPredicate condition) =>
            _stateMachine.AddTransition(from, to, condition);

        protected void AddAnyTransition(IState to, IPredicate condition) => 
            _stateMachine.AddAnyTransition(to, condition);

        protected abstract void InitStatesAndTransitions();
    }
}