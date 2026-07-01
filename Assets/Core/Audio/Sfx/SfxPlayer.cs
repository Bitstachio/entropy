using UnityEngine;

namespace Core.Audio.Sfx
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class SfxPlayer : MonoBehaviour, ISfxPlayer
    {
        private AudioSource _audioSource;

        //===== Lifecycle =====

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            
            // Loop is always true because all one-time SFX are routed through PlayOneShot,
            // which plays on a separate voice and ignores this property entirely
            _audioSource.loop = true;
        }

        //===== API =====

        public void PlayOneShot(AudioClip clip, float volume) => _audioSource.PlayOneShot(clip, volume);
        
        public void PlayLooped(AudioClip clip, float volume, float delay = 0f)
        {
            _audioSource.clip = clip;
            _audioSource.volume = volume;
            _audioSource.PlayDelayed(delay);
        }

        public void Stop() => _audioSource.Stop();
    }
}