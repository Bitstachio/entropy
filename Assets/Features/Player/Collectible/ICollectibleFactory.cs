using Core.Interfaces;

namespace Features.Player.Collectible
{
    public interface ICollectibleFactory
    {
        ISpawnable Create();
    }
}