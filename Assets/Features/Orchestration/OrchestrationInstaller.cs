using Core.ExtendedBehaviours;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Orchestration
{
    public class OrchestrationInstaller : Installer
    {
        [SerializeField] private int gameOverDelayMilliseconds;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Orchestrator>()
                .WithParameter("gameOverDelay", gameOverDelayMilliseconds);
        }
    }
}