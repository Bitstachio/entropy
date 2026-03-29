using Features.Player.Shared.Scripts;
using UnityEngine;

namespace Features.Player.Upgrade.Script
{
    public abstract class Upgrade : ScriptableObject
    {
        public abstract void Apply(PlayerStats stats);
    }
}