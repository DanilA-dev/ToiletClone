using Core;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Core
{
    public class UIBlockAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            MessageBroker.Default.Publish(new PlayerCoreAction(PlayerCoreActionType.Block));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            MessageBroker.Default.Publish(new PlayerCoreAction(PlayerCoreActionType.None));
        }
    }
}