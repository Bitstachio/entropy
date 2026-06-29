using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Progression
{
    public sealed class ProgressionScope : LifetimeScope
    {
        [SerializeField] private ProgressionView progressionView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IProgressionRepository, ProgressionRepository>(Lifetime.Singleton);
            builder.Register<IProgressionModel, ProgressionModel>(Lifetime.Singleton);
            builder.RegisterComponent(progressionView).As<IProgressionView>();
            builder.RegisterEntryPoint<ProgressionController>();
        }
    }
}