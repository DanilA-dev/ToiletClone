using Core.Level;
using Core.Player.PlayerStates.StateSerializeData;
using UnityEngine;

namespace Core.Player.PlayerStates
{
    public class PlayerMoveState : BasePlayerState
    {
        private PlayerMoveSerializeData _data;

        public PlayerMoveState(PlayerView view, LevelStageHandler stageHandle,
            PlayerMoveSerializeData moveSerializeData, PlayerController playerController) : base(view, stageHandle, playerController)
        {
            _data = moveSerializeData;
        }
        
        public override void OnEnter()
        {
            Debug.Log("Enter move state");
            _data.Agent.speed = _data.Speed;
            _data.Agent.enabled = true;
            _data.Agent.isStopped = false;
            _data.Agent.updateRotation = true;
            _data.Agent.destination = _stageHandler.GetNextStage().GetPoint.position;
        }

        public override void OnExit()
        {
            Debug.Log("Exit move state");
            _data.Agent.isStopped = true;
            _data.Agent.updateRotation = false;
            _data.Agent.enabled = false;
        }

        
    }
}