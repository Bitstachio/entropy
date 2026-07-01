using UnityEngine;

namespace Features.Player.Attack.Laser.Sfx
{
    [CreateAssetMenu(menuName = "Player/Weapons/Laser/Laser SFX Config")]
    public sealed class LaserSfxConfig : ScriptableObject
    {
        [SerializeField] private AudioClip laserStartClip;
        [SerializeField] private AudioClip laserActiveClip;
        [SerializeField] private AudioClip laserEndClip;
        
        public AudioClip LaserStartClip => laserStartClip;
        public AudioClip LaserActiveClip => laserActiveClip;
        public AudioClip LaserEndClip => laserEndClip;
    }
}