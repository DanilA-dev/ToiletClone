using Data.Skins;
using UniRx;
using UnityEngine;

namespace Data.User
{
    [CreateAssetMenu(menuName = "Data/User Data")]
    public class UserData : ScriptableObject
    {
        public ReactiveProperty<int> Money = new ReactiveProperty<int>();
    }
}