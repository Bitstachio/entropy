using System.Collections.Generic;
using Core.Tag;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Environment.Ground
{
    public sealed class GroundScope : LifetimeScope
    {
        [Header("Tags")]
        [SerializeField] [Tag] private List<string> targets;
        
        [Header("Components")]
        [SerializeField] private GroundView groundView;
        
        [Header("Stats")]
        [SerializeField] private float baselineMagnitude = 5f;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IGroundModel, GroundModel>(Lifetime.Singleton)
                .WithParameter(baselineMagnitude);
            builder.RegisterComponent(groundView).As<IGroundView>();
            builder.RegisterEntryPoint<GroundController>()
                .WithParameter<ISet<string>>(new HashSet<string>(targets));
        }
    }
}