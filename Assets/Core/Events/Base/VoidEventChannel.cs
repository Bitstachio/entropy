using System;
using Core.Events.Interfaces;
using UnityEngine;

namespace Core.Events.Base
{
    [CreateAssetMenu(menuName = "Events/Void Event Channel")]
    public sealed class VoidEventChannel : EventChannelBase, IEventPublisher
    {
        public event Action OnPublished;

        public void Publish()
        {
            if (OnPublished == null) LogNoListeners();
            else OnPublished.Invoke();
        }
    }
}