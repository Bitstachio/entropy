using Core.Foundations.Components;
using Features.Orchestration.Sfx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Orchestration
{
    public class OrchestrationInstaller : Installer
    {
        [SerializeField] private int gameOverDelayMilliseconds;

        [Header("Audio Clips")]
        [SerializeField] private AudioClip gameOverClip;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Orchestrator>()
                .WithParameter("gameOverDelay", gameOverDelayMilliseconds);
            
            builder.RegisterEntryPoint<GameOverSfxController>()
                .WithParameter(gameOverClip);
        }
    }
}