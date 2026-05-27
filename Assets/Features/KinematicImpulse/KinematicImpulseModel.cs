namespace Features.KinematicImpulse
{
    public sealed class KinematicImpulseModel : IKinematicImpulseModel
    {
        public float Magnitude { get; }

        public KinematicImpulseModel(float magnitude) => Magnitude = magnitude;
    }
}