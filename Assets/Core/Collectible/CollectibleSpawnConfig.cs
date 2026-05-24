using UnityEngine;

namespace Core.Collectible
{
    [CreateAssetMenu(menuName = "Collectibles/Collectible Config")]
    public class CollectibleSpawnConfig : ScriptableObject
    {
        [SerializeField] private float interval;
        [SerializeField] private float probability;
        [SerializeField] private float xSpeedBound;
        
        public float Interval => interval;
        public float Probability => probability;
        public float XSpeedBound => xSpeedBound;
    }
}