namespace Features.Environment.Ground
{
    public sealed class GroundModel : IGroundModel
    {
        public float ImpulseMagnitude { get; }

        public GroundModel(float magnitude) => ImpulseMagnitude = magnitude;
    }
}