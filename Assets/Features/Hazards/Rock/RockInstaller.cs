using Core.ExtendedBehaviours;
using Features.Hazards.Rock.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Hazards.Rock
{
    public class RockInstaller : Installer
    {
        [SerializeField] private RockView rockView;

        [SerializeField] private float spawnInterval = 3f;
        [SerializeField] private Transform spawnOrigin;
        [SerializeField] private float spawnXSpeedBound = 2f;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(rockView).As<IRockView>();

            builder.Register<IRockFactory, RockFactory>(Lifetime.Singleton);
            builder.RegisterEntryPoint<RockSpawner>()
                .WithParameter("interval", spawnInterval)
                .WithParameter("originPosition", spawnOrigin.position)
                .WithParameter("xSpeedBound", spawnXSpeedBound);
        }
    }
}