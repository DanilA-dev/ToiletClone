using System;
using CustomFSM.Preicate;

namespace FSM.FSM
{
    public class ActionPredicate : IPredicate
    {
        private Action _action;
        private bool _isActionComplete; 
            
        public ActionPredicate(Action action)
        {
            _action = action;
            _action += OnActionComplete;
        }

        private void OnActionComplete()
        {
            _isActionComplete = true;
        }

        public bool Evaluate() => _isActionComplete;
    }
}