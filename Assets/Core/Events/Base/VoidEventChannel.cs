using System;
using UnityEngine;

namespace Core.Events.Base
{
    [CreateAssetMenu(menuName = "Events/Void Event Channel")]
    public sealed class VoidEventChannel : EventChannelBase
    {
        public event Action OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised == null) LogNoListeners();
            else OnEventRaised.Invoke();
        }
    }
}