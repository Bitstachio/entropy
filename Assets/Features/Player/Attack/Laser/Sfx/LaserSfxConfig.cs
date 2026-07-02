using Core.Audio;
using UnityEngine;

namespace Features.Player.Attack.Laser.Sfx
{
    [CreateAssetMenu(menuName = "Player/Weapons/Laser/Laser SFX Config")]
    public sealed class LaserSfxConfig : ScriptableObject
    {
        [SerializeField] private AudioClipData startClipData;
        [SerializeField] private AudioClipData activeClipData;
        [SerializeField] private AudioClipData endClipData;

        public AudioClipData StartClipData => startClipData;
        public AudioClipData ActiveClipData => activeClipData;
        public AudioClipData EndClipData => endClipData;
    }
}