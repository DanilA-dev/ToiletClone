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
            Init();
        }

        private void Update()
        {
            _stateMachine?.OnUpdate();
        }

        private void InitStateMachine()
        {
            _stateMachine = new StateMachine();
            _stateMachine.SetState(StartState);
        }

        public void AddTransition(IState from, IState to, IPredicate condition) =>
            _stateMachine.AddTransition(from, to, condition);

        public void AddAnyTransition(IState to, IPredicate condition) => 
            _stateMachine.AddAnyTransition(to, condition);

        protected virtual void Init() {}
        protected abstract void InitStatesAndTransitions();
    }
}