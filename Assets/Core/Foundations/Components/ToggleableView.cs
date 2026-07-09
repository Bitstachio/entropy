using Core.Interfaces;
using UnityEngine;

namespace Core.Foundations.Components
{
    public abstract class ToggleableView : MonoBehaviour, IToggleable
    {
        //===== API =====
        
        public virtual void On() => gameObject.SetActive(true);

        public virtual void Off() => gameObject.SetActive(false);
    }
}