using UnityEngine;

namespace Core.Services.TimeScale
{
    public class TimeScaleService : ITimeScaleService
    {
        public void Pause() => Time.timeScale = 0f;

        public void Resume() => Time.timeScale = 1f;
    }
}