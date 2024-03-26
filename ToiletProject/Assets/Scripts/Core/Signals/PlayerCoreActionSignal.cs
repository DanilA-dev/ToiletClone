namespace Core
{
    public enum PlayerCoreActionType
    {
        None = 0,
        Attack = 1,
        Block = 2
    }
    
    public sealed class PlayerCoreActionSignal
    {
        public PlayerCoreActionType PlayerCoreActionType { get; private set; }
        
        public PlayerCoreActionSignal(PlayerCoreActionType playerCoreActionType)
        {
            PlayerCoreActionType = playerCoreActionType;
        }

    }
}