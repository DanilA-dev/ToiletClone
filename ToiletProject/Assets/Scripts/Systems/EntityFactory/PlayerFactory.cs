using Core.Player;

namespace Systems.EntityFactory
{
    public class PlayerFactory : BaseEntityFactory<PlayerController>
    {
        public PlayerFactory(PlayerController prefab) : base(prefab.gameObject) {}
    }
}