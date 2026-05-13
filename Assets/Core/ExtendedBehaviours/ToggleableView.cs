using Core.Interactions;
using UnityEngine;

namespace Core.ExtendedBehaviours
{
    public class ToggleableView : MonoBehaviour, IToggleable
    {
        //===== API =====
        
        public void On() => gameObject.SetActive(true);

        public void Off() => gameObject.SetActive(false);
    }
}