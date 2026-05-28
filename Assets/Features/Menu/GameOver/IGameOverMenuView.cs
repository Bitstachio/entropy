using System;

namespace Features.Menu.GameOver
{
    public interface IGameOverMenuView
    {
        event Action OnRetrySelected;
        event Action OnHomeSelected;

        void SetScore(string value);
        void SetHighScore(string value);
        void SetDatabaseStatus(string status);
    }
}