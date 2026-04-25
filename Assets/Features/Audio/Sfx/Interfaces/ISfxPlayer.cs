using UnityEngine;

namespace Features.Audio.Sfx.Interfaces
{
    public interface ISfxPlayer
    {
        void Play(AudioClip audioClip, float volume);
    }
}