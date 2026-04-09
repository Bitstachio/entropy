using Features.Progression.Interfaces;
using TMPro;
using UnityEngine;

namespace Features.Progression
{
    public class ProgressionView : MonoBehaviour, IProgressionView
    {
        [SerializeField] private TextMeshProUGUI scoreDisplay;
        
        //===== Interface Implementation =====
        
        public void SetScore(float score) => scoreDisplay.text = Mathf.RoundToInt(score).ToString();
    }
}