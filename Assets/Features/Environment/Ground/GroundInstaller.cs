using System.Collections.Generic;
using Core.Audio;
using Core.Foundations.Components;
using Core.Tag;
using Features.Environment.Ground.Sfx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Environment.Ground
{
    public sealed class GroundInstaller : Installer
    {
        [Header("Tags")]
        [SerializeField] [Tag] private List<string> targets;
        
        [Header("Components")]
        [SerializeField] private GroundView groundView;
        
        [Header("Stats")]
        [SerializeField] private float baselineMagnitude = 5f;

        [Header("Audio Clips")]
        [SerializeField] private AudioClip hitGroundClip;
        [SerializeField] private AudioClipConfig hitGroundClipConfig;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IGroundModel, GroundModel>(Lifetime.Singleton)
                .WithParameter(baselineMagnitude);
            builder.RegisterComponent(groundView).As<IGroundView>();
            builder.RegisterEntryPoint<GroundController>()
                .WithParameter<ISet<string>>(new HashSet<string>(targets));
            
            builder.RegisterEntryPoint<GroundHitSfxController>()
                .WithParameter(hitGroundClip)
                .WithParameter(hitGroundClipConfig);
        }
    }
}