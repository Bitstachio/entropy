using System;
using Core.Events.Interfaces;
using VContainer.Unity;

namespace Features.StatDisplay.Controllers
{
    public abstract class StatDisplayController<T> : IStartable, IDisposable
    {
        private readonly IEventListener<T> _listener;

        private readonly IStatDisplayView _view;

        protected StatDisplayController(IEventListener<T> listener, IStatDisplayView view)
        {
            _listener = listener;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start() => _listener.OnPublished += HandleStatUpdated;

        public void Dispose() => _listener.OnPublished -= HandleStatUpdated;

        //===== Event Handlers =====

        private void HandleStatUpdated(T @event)
        {
            if (@event != null) _view.Set(FormatStat(@event));
        }

        //===== Utilities =====

        protected abstract string FormatStat(T @event);
    }
}