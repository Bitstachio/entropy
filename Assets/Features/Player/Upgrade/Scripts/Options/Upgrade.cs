using Features.Player.Shared.Scripts;
using UnityEngine;

namespace Features.Player.Upgrade.Scripts.Options
{
    public abstract class Upgrade : ScriptableObject
    {
        [SerializeField] protected PlayerStats stats;

        public abstract void Apply();
    }
}