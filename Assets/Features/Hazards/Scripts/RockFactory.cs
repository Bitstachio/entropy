using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Hazards.Scripts
{
    public class RockFactory
    {
        private readonly IObjectResolver _container;
        private readonly Rock _prefab;

        public RockFactory(IObjectResolver container, Rock prefab)
        {
            _container = container;
            _prefab = prefab;
        }

        public Rock Create(Vector3 position)
        {
            return _container.Instantiate(_prefab, position, Quaternion.identity);
        }
    }
}