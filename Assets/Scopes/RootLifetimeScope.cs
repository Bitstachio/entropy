using System.Linq;
using Core.Audio.Sfx;
using Core.Events.Base;
using Core.Foundations.Components;
using Core.Services.Menu;
using Core.Services.Scene;
using Core.Services.Settings;
using Core.Services.TimeScale;
using Core.Session;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] private SceneServiceConfig sceneServiceConfig;
        [SerializeField] private float playTimeScale = 1.5f;

        protected override void Configure(IContainerBuilder builder)
        {
            //----- Event Channels -----

            builder.Register(typeof(EventChannel<>), Lifetime.Singleton)
                .AsImplementedInterfaces();

            //----- Global Services -----

            builder.Register<ITimeScaleService, TimeScaleService>(Lifetime.Singleton)
                .WithParameter("playTimeScale", playTimeScale);
            builder.Register<ISceneService, SceneService>(Lifetime.Singleton)
                .WithParameter(sceneServiceConfig);
            builder.Register<IMenuService, MenuService>(Lifetime.Singleton);
            builder.Register<ISettingsService, SettingsService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<SfxService>().As<ISfxService>();

            //----- Sessions -----

            builder.Register<GameSessionData>(Lifetime.Singleton);

            //----- Installers -----

            GetComponentsInChildren<Installer>().ToList().ForEach(i => i.Install(builder));

            //----- Input -----

            builder.Register<GameControls>(Lifetime.Singleton);
        }
    }
}