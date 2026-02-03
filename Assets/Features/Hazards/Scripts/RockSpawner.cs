using Shared.Interfaces;
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

        private IBoundsProvider _boundsProvider;
        private RockFactory _rockFactory;

        [Inject]
        public void Construct(IBoundsProvider boundsProvider, RockFactory rockFactory)
        {
            _boundsProvider = boundsProvider;
            _rockFactory = rockFactory;
        }

        //===== Lifecycle =====

        private void Update()
        {
            _timer += Time.deltaTime;
            if (!(_timer >= interval)) return;

            var position = transform.position;
            position.x = Random.Range(_boundsProvider.Min, _boundsProvider.Max);
            _rockFactory.Create(position);

            _timer = 0f;
        }
    }
}