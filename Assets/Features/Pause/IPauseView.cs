using System;
using Core.Interfaces;

namespace Features.Pause
{
    public interface IPauseView : IToggleable
    {
        event Action OnResumeSelected;
        event Action OnSettingsSelected;
        event Action OnRestartSelected;
        event Action OnAbortSelected;
    }
}