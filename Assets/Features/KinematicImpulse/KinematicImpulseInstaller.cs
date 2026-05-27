using System.Collections.Generic;
using Core.Foundations.Components;
using Core.Tag;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.KinematicImpulse
{
    public sealed class KinematicImpulseInstaller : Installer
    {
        [Header("Tags")]
        [SerializeField] [Tag] private List<string> targets;
        
        [Header("Components")]
        [SerializeField] private KinematicImpulseView kinematicImpulseView;
        
        [Header("Stats")]
        [SerializeField] private float baselineMagnitude = 5f;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IKinematicImpulseModel, KinematicImpulseModel>(Lifetime.Singleton)
                .WithParameter(baselineMagnitude);
            builder.RegisterComponent(kinematicImpulseView).As<IKinematicImpulseView>();
            builder.RegisterEntryPoint<KinematicImpulseController>()
                .WithParameter<ISet<string>>(new HashSet<string>(targets));
        }
    }
}