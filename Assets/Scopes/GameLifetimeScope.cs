using System.Linq;
using Core.Events.Base;
using Core.Foundations.Components;
using Core.Services.TimeScale;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //----- Global Services -----

            builder.Register<ITimeScaleService, TimeScaleService>(Lifetime.Singleton);
            
            //----- Feature Installers -----

            GetComponentsInChildren<Installer>().ToList().ForEach(i => i.Install(builder));

            //----- Event Channels -----

            builder.Register(typeof(EventChannel<>), Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}