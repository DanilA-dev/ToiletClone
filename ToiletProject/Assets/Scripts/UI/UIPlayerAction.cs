using Core;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Core
{
    public class UIPlayerAction : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private PlayerCoreActionType _actionType;
        
       
        public void OnPointerUp(PointerEventData eventData)
        {
            MessageBroker.Default.Publish(new PlayerCoreActionSignal(PlayerCoreActionType.None));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            MessageBroker.Default.Publish(new PlayerCoreActionSignal(_actionType));
        }
    }
}