using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Pause
{
    public sealed class PauseScope : LifetimeScope
    {
        [SerializeField] private PauseView pauseView;
        [SerializeField] private PauseInputHandler pauseInputHandler;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(pauseView).As<IPauseView>();
            builder.RegisterComponent(pauseInputHandler).As<IPauseInputHandler>();
            builder.RegisterEntryPoint<PauseController>();
        }
    }
}