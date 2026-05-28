using Core.Foundations.Components;
using Features.Menu.Sfx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Menu.GameOver
{
    public sealed class GameOverMenuInstaller : Installer
    {
        [SerializeField] private GameOverMenuConfig config;
        [SerializeField] private GameOverMenuView gameOverMenuView;

        [Header("Audio Clips")]
        [SerializeField] private AudioClip clickClip;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IGameOverMenuModel, GameOverMenuModel>(Lifetime.Singleton)
                .WithParameter(config);
            builder.RegisterComponent(gameOverMenuView).As<IGameOverMenuView>();
            builder.RegisterEntryPoint<GameOverMenuController>();

            builder.RegisterEntryPoint<MenuOptionSelectedSfxController>()
                .WithParameter(clickClip);
        }
    }
}