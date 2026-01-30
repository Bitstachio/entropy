using System.Collections;
using UnityEngine;

namespace Features.Visibility.Scripts
{
    public class VisibilityController : MonoBehaviour
    {
        private const float MinAlpha = 0f;
        private const float MaxAlpha = 1f;

        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private bool persist;

        private Coroutine _fadeRoutine;

        //===== Lifecycle =====

        private void Awake() => SetAlpha(MinAlpha);

        //===== Public Methods =====
        
        public void FadeIn() => FadeTo(MaxAlpha);

        public void FadeOut()
        {
            if (!persist) FadeTo(MinAlpha);
        }

        //===== Utilities =====

        private void FadeTo(float targetAlpha)
        {
            if (_fadeRoutine != null) StopCoroutine(_fadeRoutine);
            _fadeRoutine = StartCoroutine(FadeRoutine(targetAlpha));
        }

        private IEnumerator FadeRoutine(float targetAlpha)
        {
            var startAlpha = spriteRenderer.color.a;
            var time = 0f;

            while (time < duration)
            {
                time += Time.deltaTime;
                var alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
                SetAlpha(alpha);
                yield return null;
            }

            SetAlpha(targetAlpha);
            _fadeRoutine = null;
        }

        private void SetAlpha(float alpha)
        {
            var color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }
}