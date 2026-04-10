using Features.Progression.Interfaces;
using TMPro;
using UnityEngine;

namespace Features.Progression
{
    public class ProgressionView : MonoBehaviour, IProgressionView
    {
        [SerializeField] private TextMeshProUGUI scoreDisplay;
        [SerializeField] private TextMeshProUGUI highScoreDisplay;

        //===== Interface Implementation =====

        public void SetScore(float score) => scoreDisplay.text = Mathf.RoundToInt(score).ToString();

        public void SetHighScore(float score) => highScoreDisplay.text = Mathf.RoundToInt(score).ToString();
    }
}