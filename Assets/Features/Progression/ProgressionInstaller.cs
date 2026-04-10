using Core.ExtendedBehaviours;
using Features.Progression.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Progression
{
    public class ProgressionInstaller : Installer
    {
        [SerializeField] private ProgressionView progressionView;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IProgressionRepository, ProgressionRepository>(Lifetime.Singleton);
            builder.Register<IProgressionModel, ProgressionModel>(Lifetime.Singleton);
            builder.RegisterComponent(progressionView).As<IProgressionView>();
            builder.RegisterEntryPoint<ProgressionController>();
        }
    }
}