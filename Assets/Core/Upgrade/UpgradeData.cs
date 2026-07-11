using UnityEngine;

namespace Core.Upgrade
{
    public struct UpgradeData
    {
        public string Title { get; }
        public Sprite Icon { get; }
        public float Magnitude { get; }

        public UpgradeData(string title, Sprite icon, float magnitude)
        {
            Title = title;
            Icon = icon;
            Magnitude = magnitude;
        }
    }
}