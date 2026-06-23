using UnityEngine;

namespace Core.Audio
{
    [CreateAssetMenu(menuName = "Audio/Audio Clip Config")]
    public sealed class AudioClipConfig : ScriptableObject
    {
        [SerializeField] private float volume = 1f;

        public float Volume => volume;
    }
}