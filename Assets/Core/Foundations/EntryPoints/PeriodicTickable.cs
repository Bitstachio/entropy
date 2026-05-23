using UnityEngine;
using VContainer.Unity;

namespace Core.Foundations.EntryPoints
{
    public abstract class PeriodicTickable : ITickable
    {
        private readonly float _interval;

        private float _timer;

        protected PeriodicTickable(float interval) => _interval = interval;

        //===== Lifecycle =====

        public void Tick()
        {
            if ((_timer += Time.deltaTime) < _interval) return;
            _timer = 0;
            if (!CanExecute()) return;
            Execute();
        }

        //===== Utilities =====

        protected virtual bool CanExecute() => true;

        protected abstract void Execute();
    }
}