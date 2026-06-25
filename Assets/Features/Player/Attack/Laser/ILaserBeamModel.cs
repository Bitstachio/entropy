namespace Features.Player.Attack.Laser
{
    public interface ILaserBeamModel
    {
        float DamagePerPulse { get; }
        float PulseInterval { get; }
    }
}