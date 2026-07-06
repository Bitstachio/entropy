using UnityEngine;

namespace Core.Services.TimeScale
{
    public class TimeScaleService : ITimeScaleService
    {
        public bool IsPaused { get; private set; }

        public void Pause()
        {
            IsPaused = true;
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            IsPaused = false;
            Time.timeScale = 1f;
        }
    }
}