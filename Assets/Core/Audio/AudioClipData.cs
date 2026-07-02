using UnityEngine;

namespace Core.Audio
{
    [CreateAssetMenu(menuName = "Audio/Audio Clip Data")]
    public sealed class AudioClipData : ScriptableObject
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private float volume = 1f;

        public AudioClip Clip => clip;
        public float Volume => volume;
    }
}