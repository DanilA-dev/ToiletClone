using UnityEngine;
using Zenject;

namespace Systems.EntityFactory
{
    public abstract class BaseEntityFactory<T> where T : Entity.Entity
    {
        private GameObject _prefab;
        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _container = diContainer;
        }

        public BaseEntityFactory(GameObject prefab)
        {
            _prefab = prefab;
        }
        
        public GameObject SpawnEntity(Vector3 pos)
        {
            var newEntity = _container.InstantiatePrefab(_prefab );
            newEntity.transform.position = pos;
            return newEntity;
        }
    }
}