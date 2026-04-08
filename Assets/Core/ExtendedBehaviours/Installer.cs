using Core.Interfaces;
using UnityEngine;
using VContainer;

namespace Core.ExtendedBehaviours
{
    public abstract class Installer : MonoBehaviour, IInstaller
    {
        public abstract void Install(IContainerBuilder builder);
    }
}