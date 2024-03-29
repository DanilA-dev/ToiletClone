using System.Collections.Generic;
using UnityEngine;

namespace Data.Skins
{
    [CreateAssetMenu(menuName = "Data/Skins Container")]
    public class SkinsContainer : ScriptableObject
    {
        [SerializeField] private List<SkinData> _skinDatas;

        public List<SkinData> SkinDatas => _skinDatas;
    }
}