using Features.Menu.GameOver;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class GameOverLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameOverMenuInstaller menuInstaller;
        
        protected override void Configure(IContainerBuilder builder)
        {
            menuInstaller.Install(builder);
        }
    }
}