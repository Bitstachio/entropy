using System;

namespace Features.Player.Attack.Laser
{
    public interface ILaserInputHandler
    {
        event Action OnActivateInputDetected;
    }
}