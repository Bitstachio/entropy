using Shared.Providers;
using UnityEngine;
using VContainer;

namespace Features.Hazards.Scripts
{
    public sealed class RockSpawner : MonoBehaviour
    {
        [SerializeField] private Rock rock;
        [SerializeField] private float interval = 3f;

        private float _timer;

        //===== Dependency Injection =====

        private HorizontalBoundsProvider _boundsProvider;

        [Inject]
        public void Construct(HorizontalBoundsProvider boundsProvider) => _boundsProvider = boundsProvider;

        //===== Lifecycle =====

        private void Update()
        {
            _timer += Time.deltaTime;
            if (!(_timer >= interval)) return;

            var position = transform.position;
            position.x = Random.Range(_boundsProvider.Min, _boundsProvider.Max);
            Instantiate(rock, position, Quaternion.identity);

            _timer = 0f;
        }
    }
}