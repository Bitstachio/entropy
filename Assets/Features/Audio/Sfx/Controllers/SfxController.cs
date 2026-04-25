using System;
using Core.Events.Interfaces;
using Features.Audio.Sfx.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Audio.Sfx.Controllers
{
    public abstract class SfxController<T> : IStartable, IDisposable
    {
        private readonly IEventListener<T> _listener;

        private readonly ISfxPlayer _sfxPlayer;
        private readonly AudioClip _clip;

        protected SfxController(IEventListener<T> listener, ISfxPlayer sfxPlayer, AudioClip clip)
        {
            _listener = listener;
            _sfxPlayer = sfxPlayer;
            _clip = clip;
        }

        //===== Lifecycle =====

        public void Start() => _listener.OnPublished += Play;

        public void Dispose() => _listener.OnPublished -= Play;

        //===== Utilities =====

        private void Play(T _) => _sfxPlayer.Play(_clip, 1f);
    }
}