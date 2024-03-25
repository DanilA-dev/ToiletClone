using System;
using UnityEngine;

namespace Data.Skins
{
    public enum SkinState
    {
        None = 0,
        Closed = 1,
        Not_Purchased = 2,
        Purchased = 3,
        Equiped = 4
    }
    
    [CreateAssetMenu(menuName = "Data/Skin Data")]
    public class SkinData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private SkinState _state;


        public string Id => _id;
        public SkinState State => _state;

        [ContextMenu(nameof(Initialize))]
        private void Initialize()
        {
            _id = Guid.NewGuid().ToString();
        }
    }
}