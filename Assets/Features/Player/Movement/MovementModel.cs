using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Movement
{
    public sealed class MovementModel : IMovementModel
    {
        private readonly StatRegistry<MovementStats> stats;
        
        public MovementModel(StatRegistry<MovementStats> stats, float topSpeed)
        {
            this.stats = stats;
            stats.Register(MovementStats.TopSpeed, topSpeed);
        }
        
        //===== Interface Implementation =====
        
        public float TopSpeed => stats.Retrieve(MovementStats.TopSpeed);
    }
}