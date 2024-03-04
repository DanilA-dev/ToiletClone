﻿namespace Core
{
    public enum PlayerCoreActionType
    {
        None = 0,
        Attack = 1,
        Block = 2
    }
    
    public class PlayerCoreAction
    {
        public PlayerCoreActionType PlayerCoreActionType { get; private set; }
        
        public PlayerCoreAction(PlayerCoreActionType playerCoreActionType)
        {
            PlayerCoreActionType = playerCoreActionType;
        }

    }
}