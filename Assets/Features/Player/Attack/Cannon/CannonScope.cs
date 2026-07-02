using System.Collections.Generic;
using Core.Audio;
using Core.Interfaces;
using Core.Providers.Position;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.Tag;
using Features.Player.Attack.Cannon.Sfx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon
{
    public sealed class CannonScope : LifetimeScope
    {
        [SerializeField] [Tag] private string[] destroyTags;
        
        [Header("Prefabs")]
        [SerializeField] private CannonballView cannonballView;
        
        [Header("Providers")]
        [SerializeField] private TransformPositionProvider transformPositionProvider;
        
        [Header("Stats")]
        [SerializeField] private float baselineInterval;
        [SerializeField] private float baselineSpeed;
        [SerializeField] private float baselineDamage;

        [Header("Audio Clips")]
        [SerializeField] private AudioClip cannonShotClip;
        [SerializeField] private AudioClipData cannonShotClipData ;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(container =>
            {
                var cannonStats = container.Resolve<StatRegistry<CannonStats>>();
                cannonStats.Register(CannonStats.Interval, baselineInterval);
                cannonStats.Register(CannonStats.ProjectileSpeed, baselineSpeed);
                
                var cannonballStats = container.Resolve<StatRegistry<CannonballStats>>();
                cannonballStats.Register(CannonballStats.Damage, baselineDamage);
            });
            
            builder.RegisterComponent(cannonballView).As<ICannonballView>();
            builder.RegisterComponent(transformPositionProvider).As<IPositionProvider>();

            builder.Register<IFactory, CannonballFactory>(Lifetime.Singleton)
                .WithParameter<ISet<string>>(new HashSet<string>(destroyTags));
            builder.RegisterEntryPoint<Cannon>();
        }
    }
}