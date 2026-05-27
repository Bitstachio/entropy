using System;

namespace Features.Menu.GameOver
{
    public interface IGameOverMenuView
    {
        event Action OnRetrySelected;
        event Action OnHomeSelected;
    }
}