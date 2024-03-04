using Core.Level;
using Core.Player;
using Data;
using UnityEngine;

namespace Systems
{
    public class CoreInitializer : MonoBehaviour
    {
        [Header("Datas")]
        [SerializeField] private PlayerData _playerData;
        [Header("Controllers")]
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private LevelStageHandler _levelStageHandler;

        private void Awake()
        {
            _playerController.Init(_playerData, _levelStageHandler);
            _levelStageHandler.Init(_playerController);
        }
    }
}