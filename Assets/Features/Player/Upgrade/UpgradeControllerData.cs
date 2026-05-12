using UnityEngine;

namespace Features.Player.Upgrade
{
    [CreateAssetMenu(menuName = "Player/Upgrade Controller Data")]
    public class UpgradeControllerData : ScriptableObject
    {
        [SerializeField] private int optionCount;
        [SerializeField] private float interval;
        
        public int OptionCount => optionCount;
        public float Interval => interval;
    }
}