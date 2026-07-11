using System;
using System.Collections.Generic;
using System.Linq;
using Core.Foundations.Components;
using UnityEngine;

namespace Core.Upgrade
{
    public sealed class UpgradeView : ToggleableView, IUpgradeView
    {
        [SerializeField] private Transform optionContainer;
        [SerializeField] private UpgradeOptionView optionView;

        public event Action<int> OnUpgradeSelected;

        private readonly List<UpgradeOptionView> _activeOptions = new();

        //===== API =====

        public void SetOptions(IEnumerable<UpgradeData> options)
        {
            ClearOptions();
            foreach (var (option, index) in options.Select((value, i) => (value, i)))
            {
                var item = Instantiate(optionView, optionContainer);
                item.Setup(option.Title, UpgradeUtils.FormatMagnitude(option.Magnitude), index, SelectUpgrade);
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

        private void SelectUpgrade(int index) => OnUpgradeSelected?.Invoke(index);
    }
}