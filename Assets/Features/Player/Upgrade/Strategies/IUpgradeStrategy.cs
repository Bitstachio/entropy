namespace Features.Player.Upgrade.Strategies
{
    public interface IUpgradeStrategy
    {
        void Apply(float magnitude);
    }
}