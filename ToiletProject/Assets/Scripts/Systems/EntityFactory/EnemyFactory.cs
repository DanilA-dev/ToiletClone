using Core.Enemy;
using Zenject;

namespace Systems.EntityFactory
{
    public class EnemyFactory : BaseEntityFactory<EnemyController>
    {
        public EnemyFactory(DiContainer diContainer,EnemyController prefab) : base(diContainer,prefab) {}
    }
        
}