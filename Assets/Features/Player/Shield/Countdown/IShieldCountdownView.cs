using Core.Interfaces;

namespace Features.Player.Shield.Countdown
{
    public interface IShieldCountdownView : IToggleable
    {
        void SetRemainingTime(float time);
    }
}