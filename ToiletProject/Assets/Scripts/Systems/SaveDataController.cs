using Data.PlayerStats;
using Data.Skins;
using Data.User;
using Scriptables.Levels;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class SaveDataController
    {
        private readonly string _firstStartPath = "_firstStart";
        private readonly string _userDataPath = "_userData";
        private readonly string _playerStatsDataPath = "_playerStatsData";
        private readonly string _levelsStatesDataPath = "_levelStatesData";
        private readonly string _skinsStatesDataPath = "_skinsStatesData";
        
        private UserData _userData;
        private PlayerStatsData _playerStatsData;
        private LevelsContainer _levelsContainer;
        private SkinsContainer _skinsContainer;

        public bool IsFirstStart { get; private set; } = true;
        

        [Inject]
        private void Construct(UserData userData,
            PlayerStatsData playerStatsData, LevelsContainer levelsContainer,
            SkinsContainer skinsContainer)
        {
            _userData = userData;
            _playerStatsData = playerStatsData;
            _levelsContainer = levelsContainer;
            _skinsContainer = skinsContainer;
        }

        #region Save

        public void Save()
        {
            SaveUserData();
            SavePlayerStats();
            SaveLevelsStates();
            SaveSkinsStates();

            IsFirstStart = false;
            PlayerPrefs.SetInt(_firstStartPath, IsFirstStart ? 1 : 0);
            Debug.Log($"<color=green> Saved </color>");
        }
        private void SaveUserData()
        {
            foreach (var currency in _userData.PlayerCurrencies)
                PlayerPrefs.SetInt(_userDataPath + currency.Type,  currency.CurrentValue);
        }

        private void SavePlayerStats()
        {
            foreach (var stat in _playerStatsData.PlayerStats)
                PlayerPrefs.SetInt(_playerStatsDataPath + stat.Type, stat.CurrentValue);
        }
        
        private void SaveSkinsStates()
        {
            foreach (var skin in _skinsContainer.SkinDatas)
                PlayerPrefs.SetInt(_skinsStatesDataPath + skin.Id, (int)skin.State);
        }
        
        private void SaveLevelsStates()
        {
            foreach (var lvl in _levelsContainer.LevelsData)
                PlayerPrefs.SetInt(_levelsStatesDataPath + lvl.LevelIndex, (int)lvl.State);
        }
        

        #endregion


        #region Load

        public void Load()
        {
            if(!PlayerPrefs.HasKey(_firstStartPath))
                return;
            
            LoadUserData();
            LoadPlayerStatsData();
            LoadLevelStates();
            LoadSkinsStates();
            
            Debug.Log($"<color=yellow> Loaded </color>");
        }

        private void LoadUserData()
        {
            foreach (var currency in _userData.PlayerCurrencies)
                currency.SetValue(PlayerPrefs.GetInt(_userDataPath + currency.Type, currency.DefaultValue));
        }
        
        private void LoadPlayerStatsData()
        {
            foreach (var stat in _playerStatsData.PlayerStats)
                stat.SetStat(PlayerPrefs.GetInt(_playerStatsDataPath + stat.Type));
        }
        
        private void LoadSkinsStates()
        {
            foreach (var skinData in _skinsContainer.SkinDatas)
                skinData.SetState((SkinState)PlayerPrefs.GetInt(_skinsStatesDataPath + skinData.Id));
        }
        
        private void LoadLevelStates()
        {
            foreach (var lvl in _levelsContainer.LevelsData)
                lvl.SetState((LevelState)PlayerPrefs.GetInt(_levelsStatesDataPath + lvl.LevelIndex));
        }
        

        #endregion
       
       
        
    }
}