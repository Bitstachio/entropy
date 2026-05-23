using System;
using Core.Interfaces;
using Core.Physics;
using UnityEngine;

namespace Core.Foundations.Components
{
    public class TriggerableView : MonoBehaviour, ITriggerable
    {
        [SerializeField] private TriggerProxy triggerProxy;
        
        public event Action<Collider2D> OnTriggered;

        //===== Lifecycle =====
        
        private void OnEnable() => triggerProxy.OnEnter += HandleTriggerProxyEnter;
        
        private void OnDisable() => triggerProxy.OnEnter -= HandleTriggerProxyEnter;

        //===== Utilities =====
        
        private void HandleTriggerProxyEnter(Collider2D other) => OnTriggered?.Invoke(other);
    }
}