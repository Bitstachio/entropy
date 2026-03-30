using Features.Player.Shared.Scripts;
using UnityEngine;

namespace Features.Player.Upgrade.Scripts.Options
{
    public abstract class Upgrade : ScriptableObject
    {
        public abstract void Apply(PlayerStats stats);
    }
}