using System.Collections.Generic;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;

namespace Features.Player.Collectible
{
    public sealed class ShieldCollectibleController : CollectibleController<ShieldCollectedEvent>
    {
        public ShieldCollectibleController(
            IEventPublisher<ShieldCollectedEvent> publisher,
            ICollectibleView view,
            ISet<string> collectorTags)
            : base(publisher, view, collectorTags)
        {
        }

        protected override ShieldCollectedEvent CreateEvent(Collider2D collider) => new();
    }
}