using Systems;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Core
{
    public class UIMoneyView : MonoBehaviour
    {
        [SerializeField] private CurrencyType _currencyType;
        [SerializeField] private TMP_Text _moneyText;
        
        private ICurrencyProvider _currencyProvider;
        private Currency _currency;
        
        [Inject]
        private void Construct(ICurrencyProvider currencyProvider)
        {
            _currencyProvider = currencyProvider;
            _currency = _currencyProvider.GetCurrencyByType(_currencyType);
        }

        private void Awake() =>  _currency.OnValueChanged += UpdateText;

        private void OnEnable() =>  UpdateText(_currency.CurrentValue);

        private void OnDestroy() => _currency.OnValueChanged -= UpdateText;


        private void UpdateText(int money) => _moneyText.text = money.ToString();
        
        
    }
}