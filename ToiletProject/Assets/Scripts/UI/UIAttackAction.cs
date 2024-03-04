using Core;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Core
{
    public class UIAttackAction : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private float _attackCooldown;
        
        private float _lastClickTime;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            var curAttackTime = eventData.clickTime;
            if (Mathf.Abs(curAttackTime - _lastClickTime) < _attackCooldown)
                MessageBroker.Default.Publish(new PlayerCoreAction(PlayerCoreActionType.Attack));

            _lastClickTime = curAttackTime;
        }
    }
}