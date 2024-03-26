using UnityEngine;
using Zenject;

namespace Systems.EntityFactory
{
    public class BaseEntityFactory<T> where T : Entity.Entity
    {
        private T _prefab;
        private DiContainer _container;

        public BaseEntityFactory(DiContainer diContainer,T prefab)
        {
            _container = diContainer;
            _prefab = prefab;
        }
        
        public GameObject CreateEntity()
        {
            var newEntity = _container.InstantiatePrefab(_prefab);
            return newEntity;
        }
    }
}