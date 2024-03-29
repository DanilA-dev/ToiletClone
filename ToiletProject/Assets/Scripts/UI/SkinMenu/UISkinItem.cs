using Systems;
using Data.Skins;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Core.SkinMenu
{
    public class UISkinItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _skinNameText;
        [SerializeField] private TMP_Text _stateText;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Image _skinIcon;
        [SerializeField] private Button _useSkinButton;

        public SkinData Data { get; private set; }
        
        public void SetData(SkinData data)
        {
            Data = data;
            _priceText.text = data.State == SkinState.Avaliable_To_Purchase ? data.Price.ToString() : null;
            _skinNameText.text = data.Name;
            _skinIcon.sprite = data.Icon;
            _stateText.text = data.State.ToString();
        }

        private void Awake()
        {
            _useSkinButton.onClick.AddListener(OnUseSkin);
        }

        private void OnDestroy()
        {
            _useSkinButton.onClick.RemoveListener(OnUseSkin);
        }

        private void OnUseSkin()
        {
            MessageBroker.Default.Publish(new SkinUseSignal(Data));
        }
    }
}