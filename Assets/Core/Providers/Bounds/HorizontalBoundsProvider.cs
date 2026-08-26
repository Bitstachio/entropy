using UnityEngine;

namespace Core.Providers.Bounds
{
    public sealed class HorizontalBoundsProvider : MonoBehaviour, IBoundsProvider
    {
        public float Min { get; private set; }
        public float Max { get; private set; }

        // Prevent rocks from spawning flush against the screen edges
        private const float Padding = 1f;

        private int _lastScreenWidth;
        private int _lastScreenHeight;

        //===== Lifecycle =====

        private void Awake() => UpdateBounds();

        private void LateUpdate()
        {
            if (Screen.width == _lastScreenWidth && Screen.height == _lastScreenHeight)
                return;

            UpdateBounds();
        }

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

            _lastScreenWidth = Screen.width;
            _lastScreenHeight = Screen.height;
        }
    }
}