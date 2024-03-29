using System;
using System.Collections.Generic;
using Systems;
using Data.Skins;
using UI.Core.SkinMenu;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Core.Menu
{
    public class SkinsMenu : BaseMenu
    {
        [SerializeField] private Transform _skinItemsContnet;
        [SerializeField] private Button _returnButton;
        [SerializeField] private UISkinItem _skinItemPrefab;
        
        private List<UISkinItem> _createdSkinItems = new List<UISkinItem>();

        private SkinsContainer _skinsContainer;
        private GameState _gameState;
        
        public override MenuType MenuType => MenuType.SkinsMenu;

        [Inject]
        private void Construct(SkinsContainer skinsContainer, GameState gameState)
        {
            _gameState = gameState;
            _skinsContainer = skinsContainer;
        }

        private void OnEnable()
        {
            CreateSkins();
        }

        private void Start()
        {
            _returnButton.onClick.AddListener(() => _gameState.ChangeTab(MenuType.MainMenu));
        }

        private void OnDisable()
        {
            ClearSkins();
        }

        private void CreateSkins()
        {
            foreach (var skinData in _skinsContainer.SkinDatas)
            {
                var newSkinItem = Instantiate(_skinItemPrefab, _skinItemsContnet);
                newSkinItem.SetData(skinData);
                _createdSkinItems.Add(newSkinItem);
            }
        }

        private void ClearSkins()
        {
            if(_createdSkinItems.Count <= 0)
                return;
            
            foreach (var skinItem in _createdSkinItems)
                Destroy(skinItem.gameObject);
            
            _createdSkinItems.Clear();
        }
    }
}