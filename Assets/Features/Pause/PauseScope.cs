using Core.Foundations.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Pause
{
    public sealed class PauseScope : LifetimeScope
    {
        [SerializeField] private PauseView pauseView;
        [SerializeField] private PauseInputHandler pauseInputHandler;

        [Header("Pages")] [SerializeField] private ToggleableView mainPageView;
        [SerializeField] private BackNavigablePageView settingsPageView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register(_ =>
                new PauseMenuPages(mainPageView, settingsPageView), Lifetime.Singleton);

            builder.RegisterComponent(pauseView).As<IPauseView>();
            builder.RegisterComponent(pauseInputHandler).As<IPauseInputHandler>();
            builder.RegisterEntryPoint<PauseController>();
        }
    }
}