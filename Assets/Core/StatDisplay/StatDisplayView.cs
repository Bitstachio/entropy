using TMPro;
using UnityEngine;

namespace Core.StatDisplay
{
    public class StatDisplayView : MonoBehaviour, IStatDisplayView
    {
        [SerializeField] private TextMeshProUGUI display;
        
        public void Set(string value) => display.text = value;
    }
}