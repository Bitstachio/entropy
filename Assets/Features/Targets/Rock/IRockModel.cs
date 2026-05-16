namespace Features.Targets.Rock
{
    public interface IRockModel
    {
        float MaxDurability { get; }
        float Durability { get; }

        void TakeDamage(float amount);
    }
}