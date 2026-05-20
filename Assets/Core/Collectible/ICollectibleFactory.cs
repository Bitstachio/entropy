using Core.Interfaces;

namespace Core.Collectible
{
    public interface ICollectibleFactory
    {
        ISpawnable Create();
    }
}