namespace Systems
{
    public class PlayerUpgradeSingal
    {
        public PlayerUpgradeType UpgradeType { get; private set; }
        public PlayerUpgradeSingal(PlayerUpgradeType upgradeType)
        {
            UpgradeType = upgradeType;
        }

    }
}