using Systems.EntityFactory;
using UnityEngine;

namespace Core.Player
{
    public class PlayerSpawner : BaseEntitySpawnerService<PlayerController>
    {
        [SerializeField] private Transform _spawnPoint;
        
        private void Start()
        {
            var player = SpawnEntity();
            player.transform.position = _spawnPoint.position;
            player.transform.rotation = _spawnPoint.rotation;
        }

        private void OnDrawGizmos()
        {
            if(_spawnPoint == null)
                return;
            
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_spawnPoint.position, 1);
        }

    }
}