using UnityEngine;

namespace Features.Audio.Sfx
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class SfxPlayer : MonoBehaviour, ISfxPlayer
    {
        private AudioSource _audioSource;

        //===== Lifecycle =====

        private void Awake() => _audioSource = GetComponent<AudioSource>();

        //===== Interface Implementation =====

        public void Play(AudioClip audioClip, float volume) => _audioSource.PlayOneShot(audioClip, volume);
    }
}