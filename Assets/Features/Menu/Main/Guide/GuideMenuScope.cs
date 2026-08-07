using Core.Foundations.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Menu.Main.Guide
{
    public sealed class GuideMenuScope : LifetimeScope
    {
        [SerializeField] private GuideMenuView guideMenuView;
        [SerializeField] private BackNavigablePageView missionPageView;
        [SerializeField] private BackNavigablePageView driverSystemPageView;
        [SerializeField] private BackNavigablePageView blasterPageView;
        [SerializeField] private BackNavigablePageView laserPageView;
        [SerializeField] private BackNavigablePageView shieldPageView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register(_ =>
                new GuideMenuPages(guideMenuView, missionPageView, driverSystemPageView, blasterPageView, laserPageView,
                    shieldPageView), Lifetime.Singleton);
            builder.RegisterEntryPoint<GuideMenuController>();
        }
    }
}