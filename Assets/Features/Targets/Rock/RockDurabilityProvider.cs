using System;
using Core.Services.RunTime;
using UnityEngine;
using Random = System.Random;

namespace Features.Targets.Rock
{
    public sealed class RockDurabilityProvider : IRockDurabilityProvider
    {
        private readonly RockDurabilityConfig _config;
        private readonly IRunTimeService _runTimeService;
        private readonly Random _random;

        public RockDurabilityProvider(RockDurabilityConfig config, IRunTimeService runTimeService)
        {
            _config = config;
            _runTimeService = runTimeService;
            _random = new Random();
        }

        public float GetDurability()
        {
            var elapsedTime = _runTimeService.ElapsedTime;
            var mean = _config.InitialMean + _config.MeanGrowthRate * elapsedTime;
            var deviation = _config.InitialDeviation + _config.DeviationGrowthRate * elapsedTime;
            var u1 = 1.0 - _random.NextDouble();
            var u2 = 1.0 - _random.NextDouble();
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);
            var durability = mean + (deviation * randStdNormal);

            return Mathf.Clamp((float)durability, _config.MinDurability, _config.MaxDurability);
        }
    }
}