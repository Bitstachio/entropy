using UnityEngine;

namespace Core.Providers.Bounds
{
    [CreateAssetMenu(menuName = "Providers/Bounds/Bounds Config")]
    public sealed class BoundsConfig : ScriptableObject
    {
        [SerializeField] private float overshoot;
        
        public float Overshoot => overshoot;
    }
}