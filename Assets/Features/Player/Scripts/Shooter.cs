using UnityEngine;

namespace Features.Player.Scripts
{
    public sealed class Shooter : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private float interval = 3f;
        [SerializeField] private float speed = 5f;

        private float _timer;

        //===== Lifecycle =====

        private void Update()
        {
            _timer += Time.deltaTime;
            if (!(_timer >= interval)) return;

            var shot = Instantiate(bullet, transform.position, Quaternion.identity);
            if (shot.TryGetComponent<Bullet>(out var behaviour)) behaviour.Launch(Vector2.up, speed);

            _timer = 0f;
        }
    }
}