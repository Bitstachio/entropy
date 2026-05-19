using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatRegistry;
using VContainer.Unity;

namespace Features.StatDisplay.Controllers
{
    public abstract class StatDisplayController<TKey> : IStartable, IDisposable
    {
        private readonly IEventListener<StatRegistryUpdatedEvent<TKey>> _listener;

        private readonly IStatDisplayView _view;

        private readonly StatRegistry<TKey> _statRegistry;
        private readonly TKey _statKey;

        protected StatDisplayController(
            IEventListener<StatRegistryUpdatedEvent<TKey>> listener,
            IStatDisplayView view,
            StatRegistry<TKey> statRegistry,
            TKey statKey)
        {
            _listener = listener;
            _view = view;
            _statRegistry = statRegistry;
            _statKey = statKey;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _listener.OnPublished += HandleStatUpdated;

            // Set up the view with the current stat value since initial registration occurs before subscription
            HandleStatUpdated(new StatRegistryUpdatedEvent<TKey>(_statKey, 0f, _statRegistry.Retrieve(_statKey)));
        }

        public void Dispose() => _listener.OnPublished -= HandleStatUpdated;

        //===== Event Handlers =====

        private void HandleStatUpdated(StatRegistryUpdatedEvent<TKey> @event)
        {
            if (Equals(@event.Key, _statKey)) _view.Set(FormatStat(@event));
        }

        //===== Utilities =====

        protected abstract string FormatStat(StatRegistryUpdatedEvent<TKey> @event);
    }
}