using UnityEngine;

namespace Core.Providers.Position
{
    public interface IPositionProvider
    {
        Vector3 Position { get; }
    }
}