using Core;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Core
{
    public class UIAttackAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private float _attackCooldown;

        private float _currentClicktime;
        private float _lastClickTime;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _currentClicktime += Time.deltaTime;
            MessageBroker.Default.Publish(new PlayerCoreAction(PlayerCoreActionType.Attack));
            if(_currentClicktime > _attackCooldown)
                OnPointerUp(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _currentClicktime = 0;
            MessageBroker.Default.Publish(new PlayerCoreAction(PlayerCoreActionType.None));
        }
    }
}