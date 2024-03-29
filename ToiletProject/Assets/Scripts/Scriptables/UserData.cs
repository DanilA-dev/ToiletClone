using System.Collections.Generic;
using Systems;
using UnityEngine;

namespace Data.User
{
    [CreateAssetMenu(menuName = "Data/User Data")]
    public class UserData : ScriptableObject
    {
        [SerializeField] private List<Currency> _playerCurrencies;

        public IReadOnlyList<Currency> PlayerCurrencies => _playerCurrencies;
    }
}