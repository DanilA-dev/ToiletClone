using Data.Skins;
using UniRx;
using UnityEngine;

namespace Data.User
{
    [CreateAssetMenu(menuName = "Data/User Data")]
    public class UserData : ScriptableObject
    {
        public ReactiveProperty<int> Money { get; private set; }
        public ReactiveProperty<SkinData> Skin { get; private set; }

        private void Awake()
        {
            Money = new ReactiveProperty<int>();
            Skin = new ReactiveProperty<SkinData>();
        }

        public void SetMoney(int value) => Money.Value = value;
        public void SetSkinData(SkinData skinData) => Skin.Value = skinData;
    }
}