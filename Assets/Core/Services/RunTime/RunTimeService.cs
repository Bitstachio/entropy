using UnityEngine;
using VContainer.Unity;

namespace Core.Services.RunTime
{
    public sealed class RunTimeService : IRunTimeService, ITickable
    {
        // Difficulty scales off this instead of `Time.time`, which keeps counting across runs and menus
        public float ElapsedTime { get; private set; }

        //===== Lifecycle =====

        public void Tick() => ElapsedTime += Time.deltaTime;
    }
}
