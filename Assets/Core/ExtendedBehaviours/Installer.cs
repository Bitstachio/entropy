using UnityEngine;
using VContainer;

namespace Core.ExtendedBehaviours
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Install(IContainerBuilder builder);
    }
}