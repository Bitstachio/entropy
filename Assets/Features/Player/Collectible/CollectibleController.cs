using System;
using Core.Events.Interfaces;
using Core.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Collectible
{
    public abstract class CollectibleController<TEvent> : IStartable, IDisposable, ISpawnable
    {
        private readonly IEventPublisher<TEvent> _publisher;

        private readonly ICollectibleView _view;

        protected CollectibleController(IEventPublisher<TEvent> publisher, ICollectibleView view)
        {
            _publisher = publisher;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start() => _view.OnTriggered += HandleTriggered;

        public void Dispose() => _view.OnTriggered -= HandleTriggered;

        //===== API =====
        
        public void SetPosition(Vector2 position) => _view.SetPosition(position);

        public void SetVelocity(Vector2 velocity) => _view.SetVelocity(velocity);

        //===== Event Handlers =====

        private void HandleTriggered(Collider2D collider) => _publisher.Publish(CreateEvent(collider));

        //===== Utilities =====

        protected abstract TEvent CreateEvent(Collider2D collider);
    }
}