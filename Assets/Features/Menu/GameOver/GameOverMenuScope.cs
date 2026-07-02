using Features.Menu.Sfx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Menu.GameOver
{
    public sealed class GameOverMenuScope : LifetimeScope
    {
        [SerializeField] private GameOverMenuConfig config;
        [SerializeField] private GameOverMenuView gameOverMenuView;

        [Header("Audio Clips")]
        [SerializeField] private AudioClip clickClip;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IGameOverMenuModel, GameOverMenuModel>(Lifetime.Singleton)
                .WithParameter(config);
            builder.RegisterComponent(gameOverMenuView).As<IGameOverMenuView>();
            builder.RegisterEntryPoint<GameOverMenuController>();

            // TODO: I don't know if I should register it here
            builder.RegisterEntryPoint<MenuOptionSelectedSfxController>()
                .WithParameter(clickClip);
        }
    }
}