using Core.Events.Base;
using UnityEngine;

namespace Core.Events.Typed
{
    [CreateAssetMenu(menuName = "Events/Int Event Channel")]
    public class IntEventChannel : TypedEventChannel<int>
    {
    }
}