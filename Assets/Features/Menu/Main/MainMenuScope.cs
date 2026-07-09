using Core.Foundations.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Menu.Main
{
    public sealed class MainMenuScope : LifetimeScope
    {
        [SerializeField] private MainPageView mainPageView;
        [SerializeField] private BackNavigablePageView guidePageView;
        [SerializeField] private BackNavigablePageView creditsPageView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register(_ =>
                new MainMenuPages(mainPageView, guidePageView, creditsPageView), Lifetime.Singleton);
            builder.RegisterEntryPoint<MainMenuController>();
        }
    }
}