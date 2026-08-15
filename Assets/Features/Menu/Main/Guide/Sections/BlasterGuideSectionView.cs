using Core.Upgrade;
using Features.Player.Attack.Cannon;
using TMPro;
using UnityEngine;

namespace Features.Menu.Main.Guide.Sections
{
    public sealed class BlasterGuideSectionView : MonoBehaviour
    {
        [Header("Baseline")]
        [SerializeField] private CannonBaselineStats baselineStats;

        [Header("Upgrades")]
        [SerializeField] private UpgradeDefinition damageUpgrade;
        [SerializeField] private UpgradeDefinition fireRateUpgrade;
        [SerializeField] private UpgradeDefinition projectileSpeedUpgrade;

        [Header("Damage")]
        [SerializeField] private TextMeshProUGUI damageDisplay;
        [SerializeField] private TextMeshProUGUI damageUpgradeMeanDisplay;
        [SerializeField] private TextMeshProUGUI damageUpgradeDeviationDisplay;

        [Header("Fire Rate")]
        [SerializeField] private TextMeshProUGUI fireRateDisplay;
        [SerializeField] private TextMeshProUGUI fireRateUpgradeMeanDisplay;
        [SerializeField] private TextMeshProUGUI fireRateUpgradeDeviationDisplay;

        [Header("Projectile Speed")]
        [SerializeField] private TextMeshProUGUI projectileSpeedDisplay;
        [SerializeField] private TextMeshProUGUI projectileSpeedUpgradeMeanDisplay;
        [SerializeField] private TextMeshProUGUI projectileSpeedUpgradeDeviationDisplay;

        //===== Lifecycle =====

        private void OnEnable() => Refresh();

        //===== Utilities =====

        private void Refresh()
        {
            if (baselineStats == null)
            {
                Debug.LogWarning($"{nameof(BlasterGuideSectionView)} on {name} is missing baseline stats.", this);
                return;
            }

            SetStat(
                damageDisplay,
                damageUpgradeMeanDisplay,
                damageUpgradeDeviationDisplay,
                baselineStats.Damage,
                damageUpgrade);

            SetStat(
                fireRateDisplay,
                fireRateUpgradeMeanDisplay,
                fireRateUpgradeDeviationDisplay,
                baselineStats.FireRate,
                fireRateUpgrade);

            SetStat(
                projectileSpeedDisplay,
                projectileSpeedUpgradeMeanDisplay,
                projectileSpeedUpgradeDeviationDisplay,
                baselineStats.ProjectileSpeed,
                projectileSpeedUpgrade);
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