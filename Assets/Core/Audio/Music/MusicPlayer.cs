using UnityEngine;

namespace Core.Audio.Music
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class MusicPlayer : MonoBehaviour, IMusicPlayer
    {
        private AudioSource _audioSource;

        private void Awake() => _audioSource = GetComponent<AudioSource>();

        //===== Interface Implementation =====

        public void Play(AudioClip clip) => Play(clip, 1f);

        public void Play(AudioClip clip, float volume)
        {
            _audioSource.clip = clip;
            _audioSource.loop = true;
            _audioSource.volume = volume;
            _audioSource.Play();
        }

        public void Stop() => _audioSource.Stop();
    }
}