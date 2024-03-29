using Data.Skins;
using UniRx;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class SkinsHandler : MonoBehaviour
    {
        private ICurrencyProvider _currencyProvider;
        private SkinsContainer _skinsContainer;
        private Currency _gold;
        
        
        [Inject]
        private void Construct(ICurrencyProvider currencyProvider, SkinsContainer skinsContainer)
        {
            _currencyProvider = currencyProvider;
            _skinsContainer = skinsContainer;
            _gold = _currencyProvider.GetCurrencyByType(CurrencyType.Gold);
        }

        private void Awake()
        {
            MessageBroker.Default.Receive<SkinUseSignal>()
                .Subscribe(_ => OnSkinUsed(_.SkinData)).AddTo(gameObject);
        }

        private void OnSkinUsed(SkinData receivedSkin)
        {
            if(receivedSkin.State == SkinState.Closed ||
               receivedSkin.State == SkinState.Equiped)
                return;

            if (receivedSkin.State == SkinState.Avaliable_To_Purchase)
            {
                var equipedSkin = _skinsContainer.SkinDatas.Find(s => s.State == SkinState.Equiped);
                if (equipedSkin != null)
                    equipedSkin.SetState(SkinState.Not_Equipped);
                
                if(_gold.TryWithdraw(receivedSkin.Price))
                    receivedSkin.SetState(SkinState.Equiped);
            }
            
            if(receivedSkin.State == SkinState.Not_Equipped)
                receivedSkin.SetState(SkinState.Equiped);
           
        }
    }
}