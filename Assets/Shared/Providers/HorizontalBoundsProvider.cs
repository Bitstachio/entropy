using Shared.Interfaces;
using UnityEngine;

namespace Shared.Providers
{
    public class HorizontalBoundsProvider : MonoBehaviour, IBoundsProvider
    {
        public float Min { get; private set; }
        public float Max { get; private set; }

        // Prevent rocks from spawning flush against the screen edges
        private const float Padding = 1f;

        //===== Lifecycle =====

        private void Awake() => UpdateBounds();

        //===== Context Menu =====

        [ContextMenu("Refresh Bounds")]
        public void UpdateBounds()
        {
            var mainCamera = Camera.main;
            if (!mainCamera)
            {
                Debug.LogError("Main camera is required but not found", this);
                return;
            }

            // Do not set z to 0
            // It must be the distance from the camera to the focal plane to correctly calculate world-space boundaries
            var z = Mathf.Abs(mainCamera.transform.position.z);
            Min = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, z)).x + Padding;
            Max = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, z)).x - Padding;
        }
    }
}