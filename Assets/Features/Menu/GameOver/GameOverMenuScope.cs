using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Menu.GameOver
{
    public sealed class GameOverMenuScope : LifetimeScope
    {
        [SerializeField] private GameOverMenuView gameOverMenuView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IGameOverMenuModel, GameOverMenuModel>(Lifetime.Singleton);
            builder.RegisterComponent(gameOverMenuView).As<IGameOverMenuView>();
            builder.RegisterEntryPoint<GameOverMenuController>();
        }
    }
}