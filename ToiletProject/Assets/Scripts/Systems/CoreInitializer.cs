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
        [SerializeField] private GameState _gameState;
        [SerializeField] private PlayerData _playerData;
        [Header("Controllers")]
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private TargetController _targetController;
        [SerializeField] private LevelStageHandler _levelStageHandler;
        [SerializeField] private GameOverController _gameOverController;
        [Header("UI")] 
        [SerializeField] private MenuSwitcher _menuSwitcher;
        

        private void Awake()
        {
            _menuSwitcher.Init(_gameState);
            _levelStageHandler.Init(_playerController, _gameState);
            _gameOverController.Init();
            
            _targetController.Init(_gameState, _levelStageHandler);
            _playerController.Init(_playerData, _levelStageHandler, _gameState, _targetController);
        }

        private void Start()
        {
            MenuSwitcher.SwitchMenu(MenuType.CoreMenu);
        }
    }
}