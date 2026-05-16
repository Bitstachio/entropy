namespace Features.Targets.Rock.Interfaces
{
    public interface IRockModel
    {
        float MaxDurability { get; }
        float Durability { get; }

        void TakeDamage(float amount);
    }
}