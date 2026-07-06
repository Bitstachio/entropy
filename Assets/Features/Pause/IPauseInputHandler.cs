using System;

namespace Features.Pause
{
    public interface IPauseInputHandler
    {
        event Action OnPauseToggleInputDetected;
    }
}