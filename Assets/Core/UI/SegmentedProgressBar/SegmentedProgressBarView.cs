using Core.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.SegmentedProgressBar
{
    public class SegmentedProgressBarView : MonoBehaviour, IValueDisplay<float>
    {
        [SerializeField] private LayoutGroup container;

        private CanvasGroup[] _segments;

        //===== Lifecycle =====

        private void Awake() => CacheSegments();

        //===== API =====

        public void Set(float value)
        {
            var count = MathUtils.NormalizedToStepCount(value, _segments.Length);
            for (var i = 0; i < _segments.Length; i++)
            {
                var segment = _segments[i];
                segment.alpha = i < count ? 1f : 0f;
            }
        }

        //===== Utilities =====

        private void CacheSegments()
        {
            var count = container.transform.childCount;
            _segments = new CanvasGroup[count];

            for (var i = 0; i < count; i++)
            {
                var child = container.transform.GetChild(i);

                if (!child.TryGetComponent(out CanvasGroup canvasGroup))
                    canvasGroup = child.gameObject.AddComponent<CanvasGroup>();

                _segments[i] = canvasGroup;
            }
        }
    }
}