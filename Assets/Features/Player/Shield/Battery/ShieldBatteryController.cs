using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Foundations.EntryPoints;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.UI;
using VContainer.Unity;

namespace Features.Player.Shield.Battery
{
    public sealed class ShieldBatteryController : CountdownController, IStartable, IDisposable
    {
        private readonly IEventListener<ShieldCollectedEvent> _shieldCollectedListener;

        private readonly IValueDisplay<float> _view;

        private readonly StatRegistry<ShieldStats> _stats;

        // Duration value set when running the countdown; used for calculating the ratio for progress bar
        private float _duration;

        public ShieldBatteryController(
            IEventListener<ShieldCollectedEvent> shieldCollectedListener,
            IValueDisplay<float> view,
            StatRegistry<ShieldStats> stats)
        {
            _shieldCollectedListener = shieldCollectedListener;
            _view = view;
            _stats = stats;
        }

        //===== Lifecycle =====

        public void Start() => _shieldCollectedListener.OnPublished += HandleShieldCollected;

        public void Dispose() => _shieldCollectedListener.OnPublished -= HandleShieldCollected;

        //===== Event Handlers =====

        private void HandleShieldCollected(ShieldCollectedEvent @event)
        {
            // _view.On();
            _duration = _stats.Retrieve(ShieldStats.Duration);
            Run(_duration);
        }

        //===== Hooks =====

        protected override void OnTick()
        {
            _view.Set(Timer / _duration);
        }

        protected override void OnFinished()
        {
            // _view.Off();
        }
    }
}