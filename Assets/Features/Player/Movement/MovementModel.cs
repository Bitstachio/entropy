using Core.StatRegistry;
using Features.Player.Movement.Interfaces;

namespace Features.Player.Movement
{
    public class MovementModel : IMovementModel
    {
        // TODO: Clean up reference after deleting the Movement mono behaviour
        private readonly StatRegistry<Core.StatRegistry.StatKeys.Movement> stats;
        
        public MovementModel(StatRegistry<Core.StatRegistry.StatKeys.Movement> stats, float topSpeed)
        {
            this.stats = stats;
            stats.Register(Core.StatRegistry.StatKeys.Movement.TopSpeed, topSpeed);
        }
        
        //===== Interface Implementation =====
        
        public float TopSpeed => stats.Retrieve(Core.StatRegistry.StatKeys.Movement.TopSpeed);
    }
}