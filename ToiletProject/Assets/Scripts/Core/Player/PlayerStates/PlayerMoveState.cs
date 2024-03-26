using Core.Level;
using Core.Player.PlayerStates.StateSerializeData;
using UnityEngine;

namespace Core.Player.PlayerStates
{
    public class PlayerMoveState : BasePlayerState
    {
        private PlayerMoveSerializeData _data;
        private ILevelStageHandler _levelStageHandler;

        public PlayerMoveState(PlayerView view,
            PlayerMoveSerializeData moveSerializeData, PlayerController playerController,
            ILevelStageHandler levelStageHandler) : base(view, playerController)
        {
            _data = moveSerializeData;
            _levelStageHandler = levelStageHandler;
        }
        
        public override void OnEnter()
        {
            _view.Run();
            _data.Agent.speed = _data.Speed;
            _data.Agent.enabled = true;
            _data.Agent.isStopped = false;
            _data.Agent.updateRotation = true;
            _data.Agent.destination = _levelStageHandler.GetNextStage().GetPoint.position;
        }

        public override void OnExit()
        {
            _data.Agent.isStopped = true;
            _data.Agent.updateRotation = false;
            _data.Agent.enabled = false;
        }

        public override string ToString()
        {
            return "Move";
        }
    }
}