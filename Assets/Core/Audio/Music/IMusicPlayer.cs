using UnityEngine;

namespace Core.Audio.Music
{
    public interface IMusicPlayer
    {
        void Play(AudioClip clip);
        void Play(AudioClip clip, float volume);
        void Stop();
    }
}