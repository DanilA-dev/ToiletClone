﻿using System;
using Scriptables.Levels;
using UI.Core;
using UI.Core.Menu;
using UniRx;

namespace Systems
{
    public class GameState
    {
        public IntReactiveProperty CurrentStage = new IntReactiveProperty();
        public ReactiveProperty<LevelData> CurrentLevel = new ReactiveProperty<LevelData>();

        public bool IsGameOver { get; private set; }
        public SceneType LoadedScene { get; private set; }

        public event Action OnGameRestarted;
        public event Action<GameOverType> OnGameOver;
        public event Action<MenuType, MenuOpenSettings> OnTabChanged;
        public event Action<SceneType> OnSceneChanged;

       
        
        public void ChangeTab(MenuType type, MenuOpenSettings settings = MenuOpenSettings.FullSwitch) 
            => OnTabChanged?.Invoke(type, settings);

        public void StartLevel()
        {
            if(CurrentLevel.Value == null)
                return;
            
            ChangeScene(CurrentLevel.Value.LevelSceneName);
        }
        
        public void ChangeScene(SceneType sceneType)
        {
            IsGameOver = false;
            LoadedScene = sceneType;
            OnSceneChanged?.Invoke(sceneType);
        }
        public void SetGameOver(GameOverType gameOverType)
        {
            IsGameOver = true;
            OnGameOver?.Invoke(gameOverType);
        }

        public void RestartGame()
        {
            IsGameOver = false;
            OnGameRestarted?.Invoke();
        }
    }
}