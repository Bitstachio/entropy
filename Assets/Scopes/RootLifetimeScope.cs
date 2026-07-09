using System.Linq;
using Core.Events.Base;
using Core.Foundations.Components;
using Core.Services.Menu;
using Core.Services.Scene;
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

        protected override void Configure(IContainerBuilder builder)
        {
            //----- Event Channels -----

            builder.Register(typeof(EventChannel<>), Lifetime.Singleton)
                .AsImplementedInterfaces();

            //----- Global Services -----

            builder.Register<ITimeScaleService, TimeScaleService>(Lifetime.Singleton);
            builder.Register<ISceneService, SceneService>(Lifetime.Singleton)
                .WithParameter(sceneServiceConfig);
            builder.Register<IMenuService, MenuService>(Lifetime.Singleton);

            //----- Sessions -----

            builder.Register<GameSessionData>(Lifetime.Singleton);
            
            //----- Installers -----
            
            GetComponentsInChildren<Installer>().ToList().ForEach(i => i.Install(builder));
        }
    }
}