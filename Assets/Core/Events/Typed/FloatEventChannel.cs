using Core.Events.Base;
using UnityEngine;

namespace Core.Events.Typed
{
    [CreateAssetMenu(menuName = "Events/Float Event Channel")]
    public class FloatEventChannel : TypedEventChannel<float>
    {
    }
}