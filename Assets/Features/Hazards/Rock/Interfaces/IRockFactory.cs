using Core.Interfaces;

namespace Features.Hazards.Rock.Interfaces
{
    public interface IRockFactory
    {
        ISpawnable Create();
    }
}