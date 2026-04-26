using Features.Audio.Music.Interface;
using UnityEngine;

namespace Features.Audio.Music
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour, IMusicPlayer
    {
        private AudioSource _audioSource;

        private void Awake() => _audioSource = GetComponent<AudioSource>();

        //===== Interface Implementation =====

        public void Play(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.loop = true;
            _audioSource.Play();
        } 
        
        public void Stop() => _audioSource.Stop();
    }
}