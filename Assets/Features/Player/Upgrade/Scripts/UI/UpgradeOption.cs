using UnityEngine;

namespace Features.Player.Upgrade.Scripts.UI
{
    public class UpgradeOption : MonoBehaviour
    {
        [SerializeField] private Options.Upgrade upgrade;
        
        public Options.Upgrade Upgrade => upgrade;
    }
}
