using UnityEngine;

namespace Features.Player.Attack.Laser
{
    [CreateAssetMenu(menuName = "Player/Weapons/Laser/Laser Controller Config")]
    public sealed class LaserControllerConfig : ScriptableObject
    {
        [SerializeField] private int laserDisableDelayMs;
        
        public int LaserDisableDelayMs => laserDisableDelayMs;
    }
}