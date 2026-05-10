using Core.Interactions;

namespace Core.Interfaces
{
    public interface IFactory
    {
        ISpawnable Create();
    }
}