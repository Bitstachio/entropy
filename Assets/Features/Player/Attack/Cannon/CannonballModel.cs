using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Attack.Cannon
{
    public sealed class CannonballModel : ICannonballModel
    {
        private readonly StatRegistry<CannonStats> _stats;
        
        public CannonballModel(StatRegistry<CannonStats> stats) => _stats = stats;
        
        public float Damage => _stats.Retrieve(CannonStats.Damage);
    }
}