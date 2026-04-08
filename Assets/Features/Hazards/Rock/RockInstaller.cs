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

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IRockModel, RockModel>(Lifetime.Transient);
            builder.RegisterComponentInNewPrefab(rockView, Lifetime.Transient).As<IRockView>();
            builder.RegisterEntryPoint<RockController>(Lifetime.Transient);
        }
    }
}