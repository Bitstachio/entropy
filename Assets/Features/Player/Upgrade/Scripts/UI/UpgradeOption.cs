using TMPro;
using UnityEngine;

namespace Features.Player.Upgrade.Scripts.UI
{
    public class UpgradeOption : MonoBehaviour
    {
        [SerializeField] private Options.Upgrade upgrade;

        [SerializeField] private TextMeshProUGUI content;

        public Options.Upgrade Upgrade => upgrade;

        public void SetContent(string newContent) => content.text = newContent;
    }
}