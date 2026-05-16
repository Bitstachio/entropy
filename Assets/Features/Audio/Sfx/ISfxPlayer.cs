using UnityEngine;

namespace Features.Audio.Sfx
{
    public interface ISfxPlayer
    {
        void Play(AudioClip audioClip, float volume);
    }
}