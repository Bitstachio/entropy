using UnityEngine;

namespace Core.Providers.Bounds
{
    /// <summary>
    /// Keeps side bounce walls flush with the camera's visible edges.
    /// Fixed world walls drift off-screen when the aspect ratio changes (e.g. itch WebGL vs local 16:9).
    /// </summary>
    [DefaultExecutionOrder(-100)]
    public sealed class HorizontalBoundarySync : MonoBehaviour
    {
        [SerializeField] private Transform leftBoundary;
        [SerializeField] private Transform rightBoundary;
        [SerializeField] private HorizontalBoundsProvider boundsProvider;
        [SerializeField] private Camera targetCamera;

        private int _lastScreenWidth;
        private int _lastScreenHeight;
        private float _leftHalfWidth;
        private float _rightHalfWidth;

        private void Awake()
        {
            CacheColliderHalfWidths();
            Apply();
        }

        private void LateUpdate()
        {
            if (Screen.width == _lastScreenWidth && Screen.height == _lastScreenHeight)
                return;

            Apply();
        }

        [ContextMenu("Sync Boundaries")]
        public void Apply()
        {
            var cam = targetCamera != null ? targetCamera : Camera.main;
            if (cam == null || leftBoundary == null || rightBoundary == null)
                return;

            var z = Mathf.Abs(cam.transform.position.z);
            var leftEdge = cam.ViewportToWorldPoint(new Vector3(0f, 0.5f, z)).x;
            var rightEdge = cam.ViewportToWorldPoint(new Vector3(1f, 0.5f, z)).x;

            // Place wall centers so the inner face sits on the viewport edge.
            SetWorldX(leftBoundary, leftEdge - _leftHalfWidth);
            SetWorldX(rightBoundary, rightEdge + _rightHalfWidth);

            _lastScreenWidth = Screen.width;
            _lastScreenHeight = Screen.height;

            if (boundsProvider != null)
                boundsProvider.UpdateBounds();
        }

        private void CacheColliderHalfWidths()
        {
            _leftHalfWidth = GetColliderHalfWidth(leftBoundary);
            _rightHalfWidth = GetColliderHalfWidth(rightBoundary);
        }

        private static float GetColliderHalfWidth(Transform boundary)
        {
            if (boundary != null && boundary.TryGetComponent<BoxCollider2D>(out var box))
                return box.size.x * boundary.lossyScale.x * 0.5f;

            return 0.5f;
        }

        private static void SetWorldX(Transform boundary, float worldX)
        {
            var position = boundary.position;
            position.x = worldX;
            boundary.position = position;
        }
    }
}
