using System.Collections.Generic;
using System.Linq;
using Core.ExtendedBehaviours;
using UnityEngine;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeView : ToggleableView, IUpgradeView
    {
        [SerializeField] private Transform optionContainer;
        [SerializeField] private UpgradeOptionView optionView;

        private readonly List<UpgradeOptionView> _activeOptions = new();

        //===== API =====

        public void SetOptions(IEnumerable<UpgradeData> options)
        {
            // TODO: Remove console log
            Debug.Log("Displaying Options...");
            
            ClearOptions();
            foreach (var option in options)
            {
                var item = Instantiate(optionView, optionContainer);
                item.Setup(option.Title, "+10%"); // TODO: Remove hard-coded magnitude
                _activeOptions.Add(item);
            }
        }

        //===== Utils =====

        private void ClearOptions()
        {
            foreach (var option in _activeOptions.Where(option => option != null))
                Destroy(option.gameObject);
            _activeOptions.Clear();
        }
    }
}