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
        private readonly AudioClipData _data;

        protected SfxController(
            IEventListener<T> listener,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
        {
            _listener = listener;
            _sfxPlayer = sfxPlayer;
            _data = data ?? ScriptableObject.CreateInstance<AudioClipData>();
        }

        //===== Lifecycle =====

        public void Start() => _listener.OnPublished += Play;

        public void Dispose() => _listener.OnPublished -= Play;

        //===== Utilities =====

        private void Play(T _) => _sfxPlayer.PlayOneShot(_data.Clip, _data.Volume);
    }
}