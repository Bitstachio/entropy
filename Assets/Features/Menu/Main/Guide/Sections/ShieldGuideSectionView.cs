using Core.Collectible;
using Core.Services.Battery.InstantCharge;
using Core.Upgrade;
using TMPro;
using UnityEngine;

namespace Features.Menu.Main.Guide.Sections
{
    public sealed class ShieldGuideSectionView : MonoBehaviour
    {
        [Header("Baseline")]
        [SerializeField] private InstantChargeBatteryConfig shieldBatteryConfig;
        [SerializeField] private CollectibleSpawnConfig collectibleSpawnConfig;

        [Header("Upgrades")]
        [SerializeField] private UpgradeDefinition durationUpgrade;
        [SerializeField] private UpgradeDefinition dropChanceUpgrade;

        [Header("Duration")]
        [SerializeField] private TextMeshProUGUI durationDisplay;
        [SerializeField] private TextMeshProUGUI durationUpgradeMeanDisplay;
        [SerializeField] private TextMeshProUGUI durationUpgradeDeviationDisplay;

        [Header("Drop Chance")]
        [SerializeField] private TextMeshProUGUI dropChanceDisplay;
        [SerializeField] private TextMeshProUGUI dropChanceUpgradeMeanDisplay;
        [SerializeField] private TextMeshProUGUI dropChanceUpgradeDeviationDisplay;

        //===== Lifecycle =====

        private void OnEnable() => Refresh();

        //===== Utilities =====

        private void Refresh()
        {
            if (shieldBatteryConfig == null)
            {
                Debug.LogWarning($"{nameof(ShieldGuideSectionView)} on {name} is missing shield battery config.", this);
                return;
            }

            if (collectibleSpawnConfig == null)
            {
                Debug.LogWarning($"{nameof(ShieldGuideSectionView)} on {name} is missing collectible spawn config.",
                    this);
                return;
            }

            SetStat(
                durationDisplay,
                durationUpgradeMeanDisplay,
                durationUpgradeDeviationDisplay,
                shieldBatteryConfig.DischargeTime,
                durationUpgrade);

            SetStat(
                dropChanceDisplay,
                dropChanceUpgradeMeanDisplay,
                dropChanceUpgradeDeviationDisplay,
                collectibleSpawnConfig.Probability,
                dropChanceUpgrade);
        }

        private static void SetStat(
            TextMeshProUGUI baseDisplay,
            TextMeshProUGUI meanDisplay,
            TextMeshProUGUI deviationDisplay,
            float baseValue,
            UpgradeDefinition upgrade)
        {
            baseDisplay.text = baseValue.ToString("F1");

            if (upgrade == null)
            {
                meanDisplay.text = "-";
                deviationDisplay.text = "-";
                return;
            }

            meanDisplay.text = UpgradeUtils.FormatMagnitude(upgrade.Mean);
            deviationDisplay.text = UpgradeUtils.FormatMagnitude(1 - upgrade.Deviation);
        }
    }
}