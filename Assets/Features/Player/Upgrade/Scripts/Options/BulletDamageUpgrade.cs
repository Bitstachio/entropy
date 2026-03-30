using UnityEngine;

namespace Features.Player.Upgrade.Scripts.Options
{
    [CreateAssetMenu(fileName = "Bullet Damage Upgrade", menuName = "Player/Upgrades/Bullet Damage Upgrade")]
    public class BulletDamageUpgrade : Upgrade
    {
        public float amount = 2f;

        public override void Apply() => stats.bulletDamage += amount;
    }
}