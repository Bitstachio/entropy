using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Attack.Laser
{
    public sealed class LaserBeamModel : ILaserBeamModel
    {
        private readonly StatRegistry<LaserBeamStats> _stats;
        
        public LaserBeamModel(StatRegistry<LaserBeamStats> stats) => _stats = stats;
        
        public float DamagePerPulse => _stats.Retrieve(LaserBeamStats.DamagePerPulse);
        public float PulseInterval => _stats.Retrieve(LaserBeamStats.PulseInterval);
    }
}