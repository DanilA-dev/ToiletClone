using System;
using UnityEngine;

namespace Data.Skins
{
    public enum SkinState
    {
        None = 0,
        Closed = 1,
        Avaliable_To_Purchase = 2,
        Equiped = 3,
        Not_Equipped = 4
    }
    
    [CreateAssetMenu(menuName = "Data/Skins/New Skin")]
    public class SkinData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _price;
        [SerializeField] private SkinState _state;
        [SerializeField] private string _id;


        #region Properties
        public string Id => _id;
        public SkinState State => _state;
        public string Name => _name;
        public Sprite Icon => _icon;
        public int Price => _price;

        #endregion

        public void SetState(SkinState state) => _state = state;
        

        [ContextMenu(nameof(Initialize))]
        private void Initialize()
        {
            _id = Guid.NewGuid().ToString();
        }
    }
}