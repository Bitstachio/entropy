using UnityEngine;

namespace Core.Audio.Sfx
{
    public interface ISfxPlayer
    {
        void PlayOneShot(AudioClip clip, float volume);
        void PlayLooped(AudioClip clip, float volume, float delay = 0f);
        void Stop();
    }
}