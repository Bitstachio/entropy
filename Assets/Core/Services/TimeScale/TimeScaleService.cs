using UnityEngine;

namespace Core.Services.TimeScale
{
    public class TimeScaleService : ITimeScaleService
    {
        private readonly float _playTimeScale;

        public bool IsPaused { get; private set; }

        public TimeScaleService(float playTimeScale)
        {
            _playTimeScale = playTimeScale;
            ApplyPlayTimeScale();
        }

        public void Pause()
        {
            IsPaused = true;
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            IsPaused = false;
            ApplyPlayTimeScale();
        }

        private void ApplyPlayTimeScale() => Time.timeScale = _playTimeScale;
    }
}
