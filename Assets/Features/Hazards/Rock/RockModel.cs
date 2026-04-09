using Features.Hazards.Rock.Interfaces;

namespace Features.Hazards.Rock
{
    public class RockModel : IRockModel
    {
        public RockModel(float durability)
        {
            MaxDurability = durability;
            Durability = durability;
        }

        //===== Interface Implementation =====

        public float MaxDurability { get; }
        public float Durability { get; private set; }
        
        public void TakeDamage(float amount) => Durability -= amount;
    }
}