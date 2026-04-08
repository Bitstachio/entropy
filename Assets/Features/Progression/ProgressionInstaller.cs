using Core.ExtendedBehaviours;
using Features.Progression.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Features.Progression
{
    public class ProgressionInstaller : Installer
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IProgressionModel, ProgressionModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<ProgressionController>();
        }
    }
}