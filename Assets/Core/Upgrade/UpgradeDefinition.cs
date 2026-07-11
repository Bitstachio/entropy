using UnityEngine;

namespace Core.Upgrade
{
    [CreateAssetMenu(menuName = "Player/Upgrade Data")]
    public class UpgradeDefinition : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private Sprite icon;
        
        // Normal distribution to generate randomized upgrade magnitudes
        // Future improvement: support additional distribution types using conditional fields
        [SerializeField] private float mean;
        [SerializeField] private float deviation;

        public string Title => title;
        public Sprite Icon => icon;
        public float Mean => mean;
        public float Deviation => deviation;
    }
}