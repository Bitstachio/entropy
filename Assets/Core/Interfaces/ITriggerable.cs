using System;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ITriggerable
    {
        event Action<Collider2D> OnTriggered;
    }
}