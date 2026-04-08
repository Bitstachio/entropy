using Features.Hazards.Rock.Interfaces;

namespace Features.Hazards.Rock
{
    public class RockModel : IRockModel
    {
        public float Durability { get; private set; }
        
        public void TakeDamage(float amount) => Durability -= amount;
    }
}