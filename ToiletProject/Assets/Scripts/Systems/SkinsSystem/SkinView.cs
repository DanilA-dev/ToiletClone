using Data.Skins;
using UnityEngine;

namespace Systems
{
    public class SkinView : MonoBehaviour
    {
        [SerializeField] private SkinData _skinData;

        public SkinData SkinData => _skinData;
    }
}