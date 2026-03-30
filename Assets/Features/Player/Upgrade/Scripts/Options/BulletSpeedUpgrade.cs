using UnityEngine;

namespace Features.Player.Upgrade.Scripts.Options
{
    [CreateAssetMenu(fileName = "Bullet Speed Upgrade", menuName = "Player/Upgrades/Bullet Speed Upgrade")]
    public class BulletSpeedUpgrade : Upgrade
    {
        public float amount = 5f;

        public override void Apply() => stats.bulletSpeed += amount;
    }
}