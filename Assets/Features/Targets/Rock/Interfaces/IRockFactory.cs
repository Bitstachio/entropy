using Core.Interfaces;

namespace Features.Targets.Rock.Interfaces
{
    public interface IRockFactory
    {
        ISpawnable Create();
    }
}