using System;
using System.Collections.Generic;
using Core.Events.Interfaces;
using Core.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Core.Collectible
{
    public abstract class CollectibleController<TEvent> : IStartable, IDisposable, ISpawnable
    {
        private readonly IEventPublisher<TEvent> _publisher;

        private readonly ICollectibleView _view;

        private readonly ISet<string> _collectorTags;

        protected CollectibleController(
            IEventPublisher<TEvent> publisher,
            ICollectibleView view,
            ISet<string> collectorTags)
        {
            _publisher = publisher;
            _view = view;
            _collectorTags = collectorTags;
        }

        //===== Lifecycle =====

        public void Start() => _view.OnTriggered += HandleTriggered;

        public void Dispose() => _view.OnTriggered -= HandleTriggered;

        //===== API =====

        public void SetPosition(Vector2 position) => _view.SetPosition(position);

        public void SetVelocity(Vector2 velocity) => _view.SetVelocity(velocity);

        //===== Event Handlers =====

        private void HandleTriggered(Collider2D collider)
        {
            if (!_collectorTags.Contains(collider.tag)) return;
            _publisher.Publish(CreateEvent(collider));
            _view.Destroy();
        }

        //===== Utilities =====

        protected abstract TEvent CreateEvent(Collider2D collider);
    }
}