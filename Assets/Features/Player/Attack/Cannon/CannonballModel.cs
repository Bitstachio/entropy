using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Attack.Cannon
{
    public sealed class CannonballModel : ICannonballModel
    {
        private readonly StatRegistry<CannonballStats> _stats;
        
        public CannonballModel(StatRegistry<CannonballStats> stats) => _stats = stats;
        
        public float Damage => _stats.Retrieve(CannonballStats.Damage);
    }
}