using Systems;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceHealthBar : MonoBehaviour
{
   [SerializeField] private Image _fillAmount;
   [SerializeField] private HealthSystem _healthSystem;

   private void Awake()
   {
      _healthSystem.OnHealhChange += ChangeHealthBar;
      _healthSystem.OnDie += DisableHealthBar;
   }

   private void OnDestroy()
   {
      _healthSystem.OnHealhChange -= ChangeHealthBar;
      _healthSystem.OnDie -= DisableHealthBar;
   }

   private void DisableHealthBar()
   {
      _fillAmount.transform.parent.gameObject.SetActive(false);
   }
   
   private void ChangeHealthBar(float cur, float max)
   {
      _fillAmount.fillAmount = cur / max;
   }
}
