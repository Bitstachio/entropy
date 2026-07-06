namespace Core.Services.TimeScale
{
    public interface ITimeScaleService
    {
        public bool IsPaused { get; }

        void Pause();
        void Resume();
    }
}