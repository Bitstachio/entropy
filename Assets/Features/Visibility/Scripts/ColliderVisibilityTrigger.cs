using Shared.Constants;
using Shared.Utils;
using UnityEngine;

namespace Features.Visibility.Scripts
{
    public class ColliderVisibilityTrigger : MonoBehaviour
    {
        [SerializeField] private VisibilityController controller;

        //===== Lifecycle =====

        private void OnValidate() => ComponentValidationUtils.ValidateSingleTrigger(GetComponents<Collider2D>());

        //===== Triggers =====

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player)) controller.FadeIn();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player)) controller.FadeOut();
        }
    }
}