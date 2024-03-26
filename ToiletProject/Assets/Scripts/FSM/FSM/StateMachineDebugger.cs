using Entity;
using UnityEngine;

namespace CustomFSM.StateMachine
{
    [RequireComponent(typeof(BaseFSMActor))]
    public class StateMachineDebugger : MonoBehaviour
    {
        [SerializeField] private string _curentState;
        
        private BaseFSMActor _actor;
        private StateMachine _actorStateMachine;

        private void Awake()
        {
            _actor = GetComponent<BaseFSMActor>();
            _actorStateMachine = _actor.StateMachine;
        }

        private void Update()
        {
            if(_actorStateMachine == null)
                return;

            _curentState = _actorStateMachine.CurrentStateNode.State.ToString();
        }
    }
}