namespace Features.Progression
{
    public static class ProgressionUtils
    {
        // Compares s1 and s2 as integers since that's how scores are displayed
        // A new high score only counts if its rounded value is actually higher
        public static float MaxScore(float s1, float s2) =>
            (int)(s1 + 0.5f) > (int)(s2 + 0.5f)
                ? s1
                : s2;
    }
}