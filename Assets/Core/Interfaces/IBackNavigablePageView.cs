using System;

namespace Core.Interfaces
{
    public interface IBackNavigablePageView
    {
        event Action OnBackSelected;
    }
}