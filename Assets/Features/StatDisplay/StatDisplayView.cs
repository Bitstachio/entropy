using TMPro;
using UnityEngine;

namespace Features.StatDisplay
{
    public class StatDisplayView : MonoBehaviour, IStatDisplayView
    {
        [SerializeField] private TextMeshProUGUI display;
        
        public void Set(string value) => display.text = value;
    }
}