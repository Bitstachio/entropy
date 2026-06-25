using System;
using Core.Interfaces;
using UnityEngine;

namespace Features.Player.Attack.Laser
{
    public interface ILaserBeamView : IToggleable
    {
        event Action<Collider2D> OnEnterTrigger;
        event Action<Collider2D> OnExitTrigger;
    }
}