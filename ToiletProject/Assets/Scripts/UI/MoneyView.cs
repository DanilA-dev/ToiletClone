using Data.User;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Core
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyText;
        
        private UserData _userData;
        
        [Inject]
        private void Construct(UserData userData)
        {
            _userData = userData;
        }

        private void Awake() => _userData.Money.Subscribe(UpdateText).AddTo(gameObject);
        private void OnEnable() => UpdateText(_userData.Money.Value);
        private void UpdateText(int money) => _moneyText.text = money.ToString();
        
        
    }
}