using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Attack.Blaster
{
    public sealed class BoltModel : IBoltModel
    {
        private readonly StatRegistry<BlasterStats> _stats;
        
        public BoltModel(StatRegistry<BlasterStats> stats) => _stats = stats;
        
        public float Damage => _stats.Retrieve(BlasterStats.Damage);
    }
}
