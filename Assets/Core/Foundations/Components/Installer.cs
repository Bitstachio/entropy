using UnityEngine;
using VContainer;

namespace Core.Foundations.Components
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Install(IContainerBuilder builder);
    }
}