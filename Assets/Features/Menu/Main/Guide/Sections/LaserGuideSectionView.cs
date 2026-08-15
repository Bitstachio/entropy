using Core.Services.Battery.TimedCharge;
using Core.Upgrade;
using Features.Player.Attack.Laser;
using TMPro;
using UnityEngine;

namespace Features.Menu.Main.Guide.Sections
{
    public sealed class LaserGuideSectionView : MonoBehaviour
    {
        [Header("Baseline")]
        [SerializeField] private LaserBaselineStats baselineStats;
        [SerializeField] private TimedChargeBatteryConfig laserBatteryConfig;

        [Header("Upgrades")]
        [SerializeField] private UpgradeDefinition damageUpgrade;
        [SerializeField] private UpgradeDefinition pulseIntervalUpgrade;
        [SerializeField] private UpgradeDefinition durationUpgrade;
        
        [Header("Damage Per Pulse")]
        [SerializeField] private TextMeshProUGUI damageDisplay;
        [SerializeField] private TextMeshProUGUI damageUpgradeMeanDisplay;
        [SerializeField] private TextMeshProUGUI damageUpgradeDeviationDisplay;

        [Header("Pulse Interval")]
        [SerializeField] private TextMeshProUGUI pulseIntervalDisplay;
        [SerializeField] private TextMeshProUGUI pulseIntervalUpgradeMeanDisplay;
        [SerializeField] private TextMeshProUGUI pulseIntervalUpgradeDeviationDisplay;

        [Header("Duration")]
        [SerializeField] private TextMeshProUGUI durationDisplay;
        [SerializeField] private TextMeshProUGUI durationUpgradeMeanDisplay;
        [SerializeField] private TextMeshProUGUI durationUpgradeDeviationDisplay;

        //===== Lifecycle =====

        private void OnEnable() => Refresh();

        //===== Utilities =====

        private void Refresh()
        {
            if (baselineStats == null)
            {
                Debug.LogWarning($"{nameof(LaserGuideSectionView)} on {name} is missing baseline stats.", this);
                return;
            }

            SetStat(
                damageDisplay,
                damageUpgradeMeanDisplay,
                damageUpgradeDeviationDisplay,
                baselineStats.DamagePerPulse,
                damageUpgrade);

            SetStat(
                pulseIntervalDisplay,
                pulseIntervalUpgradeMeanDisplay,
                pulseIntervalUpgradeDeviationDisplay,
                baselineStats.PulseInterval,
                pulseIntervalUpgrade);

            SetStat(
                durationDisplay,
                durationUpgradeMeanDisplay,
                durationUpgradeDeviationDisplay,
                laserBatteryConfig.DischargeTime,
                durationUpgrade);
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