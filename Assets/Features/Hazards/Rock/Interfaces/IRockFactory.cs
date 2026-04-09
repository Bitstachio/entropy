using Core.Gameplay.Interfaces;

namespace Features.Hazards.Rock.Interfaces
{
    public interface IRockFactory
    {
        ISpawnable Create();
    }
}