using Core.Enemy;
using Core.Player;
using UnityEngine;

namespace Systems.EntityFactory
{
    public class EntitySpawner : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private PlayerController _playerPrefab;
        [SerializeField] private Transform _playerSpawnPos;
        [Header("Enemy")]
        [SerializeField] private EnemyController _enemyPrefab;

        private PlayerFactory _playerFactory;
        private EnemyFactory _enemyFactory;

        public void Init()
        {
            _playerFactory = new PlayerFactory(_playerPrefab);
            _enemyFactory = new EnemyFactory(_enemyPrefab);
        }

        public PlayerController SpawnPlayer() => _playerFactory.SpawnEntity(_playerSpawnPos.position).GetComponent<PlayerController>();
        public EnemyController SpawnEnemy(Vector3 pos) => _enemyFactory.SpawnEntity(pos).GetComponent<EnemyController>();

    }
}