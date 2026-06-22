using Core.Foundations.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Shield.Countdown
{
    public sealed class ShieldCountdownInstaller : Installer
    {
        [SerializeField] private ShieldCountdownView shieldCountdownView;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(shieldCountdownView).As<IShieldCountdownView>();
            builder.RegisterEntryPoint<ShieldCountdownController>();
        }
    }
}