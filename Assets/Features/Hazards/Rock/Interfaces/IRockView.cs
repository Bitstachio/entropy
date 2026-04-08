using System;

namespace Features.Hazards.Rock.Interfaces
{
    public interface IRockView
    {
        event Action OnHitPlayer;
        event Action<float> OnDamageTaken;
    }
}