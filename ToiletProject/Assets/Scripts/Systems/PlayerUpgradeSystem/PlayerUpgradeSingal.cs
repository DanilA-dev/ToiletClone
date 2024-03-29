namespace Systems
{
    public class PlayerUpgradeSingal
    {
        public PlayerStatType StatType { get; private set; }
        public PlayerUpgradeSingal(PlayerStatType statType)
        {
            StatType = statType;
        }

    }
}