using System;
using Core.Level;
using Core.Player;
using Core.Player.PlayerStates;
using Data;
using UI.Core;
using UI.Core.Menu;
using UnityEngine;

namespace Systems
{
    public class CoreInitializer : MonoBehaviour
    {
        [Header("Datas")] 
        [SerializeField] private PlayerData _playerData;
        [Header("Controllers")]
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private TargetController _targetController;
        [SerializeField] private GameOverController _gameOverController;
        [SerializeField] private LevelStageHandler _levelStageHandler;
        [SerializeField] private PlayerActionReceiver _actionReceiver;
        [Header("UI")] 
        [SerializeField] private MenuSwitcher _menuSwitcher;
        
         private GameState _gameState;

        private void Awake()
        {
            _gameState = new GameState();
            
            _menuSwitcher.Init(_gameState);
            _levelStageHandler.Init(_playerController, _gameState);
            _gameOverController.Init(_gameState);
            _targetController.Init(_gameState, _levelStageHandler);
            _playerController.Init(_playerData, _levelStageHandler, _gameState, _targetController, _actionReceiver);
            
        }

        private void Start()
        {
            _gameState.CurrentTab.Value = MenuType.CoreMenu;
        }
    }
}