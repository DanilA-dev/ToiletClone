using UnityEngine;
using Zenject;

namespace Systems.EntityFactory
{
    public abstract class BaseEntitySpawnerService<T> : MonoBehaviour where T : Entity.Entity
    {
        [SerializeField] private T _prefab;

        private DiContainer _diContainer;
        private BaseEntityFactory<T> _factory;
        
        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        protected virtual void Awake()
        {
            _factory = new BaseEntityFactory<T>(_diContainer, _prefab);
        }

        public virtual T SpawnEntity()
        {
            return _factory.CreateEntity().GetComponent<T>();
        }

    }
}