namespace Core.Upgrade
{
    public interface IUpgradeStrategy
    {
        void Apply(float magnitude);
    }
}