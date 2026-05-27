using System;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ICollidable
    {
        event Action<Collision2D> OnCollided;
    }
}