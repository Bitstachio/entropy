using UnityEngine;

namespace Features.Audio.Music.Interface
{
    public interface IMusicPlayer
    {
        void Play(AudioClip clip);
        void Stop();
    }
}