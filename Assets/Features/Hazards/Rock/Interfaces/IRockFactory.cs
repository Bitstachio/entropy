using Core.Interactions;

namespace Features.Hazards.Rock.Interfaces
{
    public interface IRockFactory
    {
        ISpawnable Create();
    }
}