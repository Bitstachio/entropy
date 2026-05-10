using Features.Player.Attack.Cannon.Interfaces;

namespace Features.Player.Attack.Cannon
{
    // TODO: Incorporate stat registry
    public sealed class CannonballModel : ICannonballModel
    {
        public CannonballModel(float damage) => Damage = damage;
        
        public float Damage { get; }
    }
}