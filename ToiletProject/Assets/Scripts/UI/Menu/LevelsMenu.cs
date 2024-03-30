using System;
using System.Collections.Generic;
using Systems;
using Scriptables.Levels;
using UI.Core.LevelsMenu;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Core.Menu
{
    public class LevelsMenu : BaseMenu
    {
        [SerializeField] private Transform _levelsContent;
        [SerializeField] private UILevelItem _levelItemPrefab;
        [SerializeField] private Button _returnButton;

        private List<UILevelItem> _createdItems = new List<UILevelItem>();
        
        private GameState _gameState;
        private LevelsContainer _levelsContainer;
        
        public override MenuType MenuType => MenuType.LevelsMenu;

        [Inject]
        private void Construct(GameState gameState, LevelsContainer levelsContainer)
        {
            _gameState = gameState;
            _levelsContainer = levelsContainer;
        }

        private void OnEnable()
        {
            CreateLevels();
        }

        private void Start()
        {
            _gameState.CurrentLevel.Subscribe(SetSelectedLevelView).AddTo(gameObject);
            _returnButton.onClick.AddListener((() => _gameState.ChangeTab(MenuType.MainMenu)));
        }

        private void OnDisable()
        {
            ClearLevels();
        }

        private void CreateLevels()
        {
            for (int i = 0; i < _levelsContainer.LevelsData.Count; i++)
            {
                var lvlData = _levelsContainer.LevelsData[i];
                var newUIItem = Instantiate(_levelItemPrefab, _levelsContent);
                newUIItem.SetData(lvlData);
                _createdItems.Add(newUIItem);
            }   
        }

        private void ClearLevels()
        {
            if (_createdItems.Count <= 0)
                return;
            
            _createdItems.ForEach(g => Destroy(g.gameObject));
            _createdItems.Clear();
        }

        private void SetSelectedLevelView(LevelData levelData)
        {
            DeselectAll();
            var lvlItem = _createdItems.Find(l => l.Data == levelData);
            lvlItem?.ToggleSelectBorder(true);
        }
        
        public void DeselectAll()
        {
            if (_createdItems.Count <= 0)
                return;
            
            _createdItems.ForEach(i => i.ToggleSelectBorder(false));
        }
        
        
    }
}