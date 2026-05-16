using UnityEngine;

namespace Features.Player.Upgrade
{
    [CreateAssetMenu(menuName = "Player/Upgrade Controller Config")]
    public class UpgradeControllerConfig : ScriptableObject
    {
        [SerializeField] private int optionCount;
        [SerializeField] private float interval;
        
        public int OptionCount => optionCount;
        public float Interval => interval;
    }
}