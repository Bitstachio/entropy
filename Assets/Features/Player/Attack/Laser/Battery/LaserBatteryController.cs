using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Foundations.EntryPoints;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.UI;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.Battery
{
    public sealed class LaserBatteryController : CountdownController, IStartable, IDisposable
    {
        private readonly IEventListener<LaserActivated> _laserActivatedListener;
        
        private readonly IValueDisplay<float> _view;

        private readonly StatRegistry<LaserBeamStats> _stats;
        
        // Duration value set when running the countdown; used for calculating the ratio for progress bar
        private float _duration;
        
        public LaserBatteryController(
            IEventListener<LaserActivated> laserActivatedListener,
            IValueDisplay<float> view,
            StatRegistry<LaserBeamStats> stats)
        {
            _laserActivatedListener = laserActivatedListener;
            _view = view;
            _stats = stats;
        }

        //===== Lifecycle =====
        
        public void Start() => _laserActivatedListener.OnPublished += HandleLaserActivated;

        public void Dispose() => _laserActivatedListener.OnPublished -= HandleLaserActivated;

        //===== Event Handlers =====

        private void HandleLaserActivated(LaserActivated @event)
        {
            _duration = _stats.Retrieve(LaserBeamStats.Duration);
            Run(_duration);
        }
        
        //===== Hooks =====
        
        protected override void OnTick()
        {
            _view.Set(Timer / _duration);
        }

        protected override void OnFinished()
        {
            throw new System.NotImplementedException();
        }
    }
}