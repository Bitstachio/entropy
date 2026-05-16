using UnityEngine;

namespace Features.Audio.Music
{
    public interface IMusicPlayer
    {
        void Play(AudioClip clip);
        void Stop();
    }
}