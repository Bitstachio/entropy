using UnityEngine;

namespace Features.Player.Upgrade.Scripts.Options
{
    [CreateAssetMenu(fileName = "Bullet Interval Upgrade", menuName = "Player/Upgrades/Bullet Interval Upgrade")]
    public class BulletIntervalUpgrade : Upgrade
    {
        public float multiplier = 0.75f;

        public override void Apply() => stats.bulletInterval *= multiplier;
    }
}