using UnityEngine;

namespace Core.Upgrade
{
    [CreateAssetMenu(menuName = "Player/Upgrade Controller Config")]
    public sealed class UpgradeControllerConfig : ScriptableObject
    {
        [SerializeField] private int optionCount;
        [SerializeField] private float interval;
        
        public int OptionCount => optionCount;
        public float Interval => interval;
    }
}