using System;
using Core.Events.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Core.Audio.Sfx
{
    public abstract class SfxController<T> : IStartable, IDisposable
    {
        private readonly IEventListener<T> _listener;

        private readonly ISfxPlayer _sfxPlayer;
        private readonly AudioClip _clip;
        private readonly AudioClipConfig _config;

        protected SfxController(
            IEventListener<T> listener,
            ISfxPlayer sfxPlayer,
            AudioClip clip,
            AudioClipConfig config)
        {
            _listener = listener;
            _sfxPlayer = sfxPlayer;
            _clip = clip;
            _config = config ?? ScriptableObject.CreateInstance<AudioClipConfig>();
        }

        //===== Lifecycle =====

        public void Start() => _listener.OnPublished += Play;

        public void Dispose() => _listener.OnPublished -= Play;

        //===== Utilities =====

        private void Play(T _) => _sfxPlayer.PlayOneShot(_clip, _config.Volume);
    }
}