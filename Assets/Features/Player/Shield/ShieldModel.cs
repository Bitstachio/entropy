using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Shield
{
    public class ShieldModel : IShieldModel
    {
        public float Duration => _stats.Retrieve(ShieldStats.Duration);

        private readonly StatRegistry<ShieldStats> _stats;

        public ShieldModel(StatRegistry<ShieldStats> stats) => _stats = stats;
    }
}