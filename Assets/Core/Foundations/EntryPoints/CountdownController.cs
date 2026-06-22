using UnityEngine;
using VContainer.Unity;

namespace Core.Foundations.EntryPoints
{
    public abstract class CountdownController : ITickable
    {
        protected float Timer;
        protected bool IsActive;

        //===== Lifecycle =====

        public void Tick()
        {
            if (!IsActive) return;

            Timer = Mathf.Max(0f, Timer - Time.deltaTime);
            OnTick();

            if (Timer > 0f) return;

            IsActive = false;
            OnFinished();
        }

        //===== Hooks =====

        protected abstract void OnTick();

        protected abstract void OnFinished();

        //===== Utilities =====

        protected void Run(float duration)
        {
            Timer = duration;
            IsActive = true;
        }
    }
}