using UnityEngine;

namespace Features.Player.Attack.Laser
{
    [CreateAssetMenu(menuName = "Player/Weapons/Laser/Laser Controller Config")]
    public sealed class LaserControllerConfig : ScriptableObject
    {
        [SerializeField] private int laserDisableDelayMs;
        [SerializeField] private Color targetHitTint = Color.red;
        
        public int LaserDisableDelayMs => laserDisableDelayMs;
        public Color TargetHitTint => targetHitTint;
    }
}