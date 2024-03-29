using Data.Skins;
using UnityEngine;

namespace Systems
{
    public class SkinInitializerHandler : MonoBehaviour
    {
        private SkinView[] _skinViews;

        private void Awake()
        {
            _skinViews = GetComponentsInChildren<SkinView>();
        }

        private void Start()
        {
            InitSkin();
        }

        private void InitSkin()
        {
            if(null == _skinViews)
                return;

            foreach (var skinView in _skinViews)
                skinView.gameObject.SetActive(skinView.SkinData.State == SkinState.Equiped);
        }
    }
}