using Core.Interfaces;
using UnityEngine;

namespace Core.Foundations.Components
{
    public abstract class ToggleableView : MonoBehaviour, IToggleable
    {
        //===== API =====
        
        public void On() => gameObject.SetActive(true);

        public void Off() => gameObject.SetActive(false);
    }
}