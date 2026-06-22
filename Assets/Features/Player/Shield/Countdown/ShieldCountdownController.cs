using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Foundations.EntryPoints;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using VContainer.Unity;

namespace Features.Player.Shield.Countdown
{
    public sealed class ShieldCountdownController : CountdownController, IStartable, IDisposable
    {
        private readonly IEventListener<ShieldCollectedEvent> _shieldCollectedListener;

        private readonly IShieldCountdownView _view;

        private readonly StatRegistry<ShieldStats> _stats;

        public ShieldCountdownController(
            IEventListener<ShieldCollectedEvent> shieldCollectedListener,
            IShieldCountdownView view,
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
            _view.On();
            Run(_stats.Retrieve(ShieldStats.Duration));
        }

        //===== Hooks =====

        protected override void OnTick()
        {
            _view.SetRemainingTime(Timer);
        }

        protected override void OnFinished() => _view.Off();
    }
}