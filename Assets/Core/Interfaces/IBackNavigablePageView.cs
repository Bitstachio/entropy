using System;

namespace Core.Interfaces
{
    public interface IBackNavigablePageView : IToggleable
    {
        event Action OnBackSelected;
    }
}