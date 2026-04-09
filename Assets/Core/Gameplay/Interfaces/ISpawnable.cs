using UnityEngine;

namespace Core.Gameplay.Interfaces
{
    public interface ISpawnable
    {
        void Spawn(Vector3 position, Vector3 velocity);
    }
}