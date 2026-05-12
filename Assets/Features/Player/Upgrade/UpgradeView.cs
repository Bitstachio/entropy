using System.Collections.Generic;
using UnityEngine;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeView : MonoBehaviour, IUpgradeView
    {
        public void SetOptions(IEnumerable<UpgradeData> options)
        {
            Debug.Log("Displaying Options...");
        }
    }
}