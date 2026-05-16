using Core.Interfaces;

namespace Features.Targets.Rock
{
    public interface IRockFactory
    {
        ISpawnable Create();
    }
}