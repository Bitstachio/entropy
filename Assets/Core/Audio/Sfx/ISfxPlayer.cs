using UnityEngine;

namespace Core.Audio.Sfx
{
    public interface ISfxPlayer
    {
        void Play(AudioClip audioClip, float volume);
    }
}