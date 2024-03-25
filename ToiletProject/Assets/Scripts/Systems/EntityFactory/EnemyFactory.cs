using Core.Enemy;

namespace Systems.EntityFactory
{
    public class EnemyFactory : BaseEntityFactory<EnemyController>
    {
        public EnemyFactory(EnemyController prefab) : base(prefab.gameObject) {}
    }
        
}