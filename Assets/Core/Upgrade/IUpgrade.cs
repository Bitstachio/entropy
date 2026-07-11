namespace Core.Upgrade
{
    public interface IUpgrade : IUpgradeStrategy
    {
        UpgradeDefinition Definition { get; }
    }
}