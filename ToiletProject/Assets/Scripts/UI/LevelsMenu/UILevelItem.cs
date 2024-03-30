using Systems;
using Scriptables.Levels;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Core.LevelsMenu
{
    public class UILevelItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelIndex;
        [SerializeField] private Image _selectBorder;
        [SerializeField] private Image _lockIcon;
        [SerializeField] private Button _useButton;

        private LevelData _data;

        public LevelData Data => _data;

        public void SetData(LevelData data)
        {
            _data = data;
            _levelIndex.text = data.LevelIndex.ToString();
            _lockIcon.gameObject.SetActive(data.State == LevelState.Closed);
            ToggleSelectBorder(data.State == LevelState.Selected);
        }
        
        private void Awake()
        {
            _useButton.onClick.AddListener(OnUseLevelItem);
        }

        public void ToggleSelectBorder(bool value) => _selectBorder.gameObject.SetActive(value);
        
        private void OnUseLevelItem()
        {
            MessageBroker.Default.Publish(new LevelUseSignal(_data));
        }
    }
}