using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Settings
{
    public sealed class SettingsScope : LifetimeScope
    {
        [SerializeField] private SettingsView settingsView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(settingsView).As<ISettingsView>();
            builder.RegisterEntryPoint<SettingsController>();
        }
    }
}