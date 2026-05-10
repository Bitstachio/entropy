using UnityEngine;

namespace Core.Providers.Position
{
    public class TransformPositionProvider : MonoBehaviour, IPositionProvider
    {
        public Vector3 Position => transform.position;
    }
}