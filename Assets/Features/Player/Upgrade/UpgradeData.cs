using UnityEngine;

namespace Features.Player.Upgrade
{
    [CreateAssetMenu(menuName = "Player/Upgrade Data")]
    public class UpgradeData : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private Sprite icon;

        public string Title => title;
        public Sprite Icon => icon;
    }
}