using Core.Player;
using Zenject;

namespace Systems.EntityFactory
{
    public class PlayerFactory : BaseEntityFactory<PlayerController>
    {
        public PlayerFactory(DiContainer diContainer,PlayerController prefab) : base(diContainer,prefab) {}
    }
}