using UnityEngine;

namespace Core.Events.Base
{
    public abstract class EventChannelBase : ScriptableObject
    {
        protected void LogNoListeners() =>
            Debug.LogWarning($"[EventChannel] `{name}` was raised but has no listeners.");
    }
}