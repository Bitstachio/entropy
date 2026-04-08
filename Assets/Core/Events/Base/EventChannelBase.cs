using UnityEngine;

namespace Core.Events.Base
{
    public abstract class EventChannelBase
    {
        protected void LogNoListeners() =>
            // TODO: Figure out what to use instead of `name`
            Debug.LogWarning($"[EventChannel] `name` was raised but has no listeners.");
    }
}