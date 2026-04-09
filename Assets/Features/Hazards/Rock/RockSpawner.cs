using Features.Hazards.Rock.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Hazards.Rock
{
    public sealed class RockSpawner : ITickable
    {
        // private readonly IBoundsProvider _boundsProvider;
        private readonly IRockFactory _rockFactory;
        private readonly Vector3 _originPosition;
        private readonly float _interval;
        private readonly float _xSpeedBound;

        private float _timer;

        public RockSpawner(
            // IBoundsProvider boundsProvider,
            IRockFactory rockFactory,
            Vector3 originPosition,
            float interval,
            float xSpeedBound)
        {
            // _boundsProvider = boundsProvider;
            _rockFactory = rockFactory;
            _originPosition = originPosition;
            _interval = interval;
            _xSpeedBound = xSpeedBound;
        }

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _interval) return;

            // TODO: Remove
            Debug.Log("Spawning rock");
            // var x = Random.Range(_boundsProvider.Min, _boundsProvider.Max);
            var position = new Vector3(0, _originPosition.y, 0);
            var rock = _rockFactory.Create();
            
            var horizontalSpeed = Random.Range(-_xSpeedBound, _xSpeedBound);
            
            rock.Spawn(position, new Vector3(horizontalSpeed, 0, 0));
            // var rb = rock.Rigidbody;
            // if (rb != null) rb.linearVelocity = new Vector2(horizontalSpeed, rb.linearVelocity.y);

            _timer = 0f;
        }
    }
}