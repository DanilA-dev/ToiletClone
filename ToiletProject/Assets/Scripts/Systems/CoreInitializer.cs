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

        private void Awake()
        {
            _menuSwitcher.Init();
            _levelStageHandler.Init(_playerController);
            _gameOverController.Init();
            _targetController.Init(_levelStageHandler);
            _playerController.Init(_playerData, _levelStageHandler,_targetController, _actionReceiver);
            
        }

        private void Start()
        {
            GameState.CurrentTab.Value = MenuType.CoreMenu;
        }
    }
}