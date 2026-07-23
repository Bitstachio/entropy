using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Upgrade.ProgressionDisplay
{
    [CreateAssetMenu(menuName = "Player/Upgrade/Upgrade Progression Status Config")]
    public sealed class UpgradeProgressionStatusConfig : ScriptableObject
    {
        [SerializeField] private Entry[] entries;

        public IReadOnlyList<Entry> Entries => entries;

        [Serializable] public struct Entry
        {
            [Range(0f, 1f)] public float threshold;
            public string status;
        }
    }
}