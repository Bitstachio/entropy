using Features.Player.Shared.Scripts;
using UnityEngine;

namespace Features.Player.Upgrade.Scripts.Options
{
    [CreateAssetMenu(fileName = "Bullet Damage Upgrade", menuName = "Player/Upgrades/Bullet Damage Upgrade")]
    public class BulletDamageUpgrade : Upgrade
    {
        public float amount = 5f;

        public override void Apply(PlayerStats stats) => stats.bulletDamage += amount;
    }
}