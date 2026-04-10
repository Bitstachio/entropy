using Features.Progression.Interfaces;
using UnityEngine;

namespace Features.Progression
{
    public class ProgressionRepository : IProgressionRepository
    {
        private const string HighScoreKey = "Progression_HighScore";

        //===== Interface Implementation =====

        public int LoadHighScore() => PlayerPrefs.GetInt(HighScoreKey, 0);
        
        public void SaveHighScore(int score)
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
            PlayerPrefs.Save();
        }
    }
}