using TMPro;
using UnityEngine;

namespace GameOver
{
    public class ScoringAfterGameOver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private TextMeshProUGUI _bestScore;

        private int bestScore;

        private void Start()
        {
            bestScore = GetBestScoreFromStorage();
            _bestScore.text = bestScore.ToString();
        }

        public void Scoring(int score)
        {
            _currentScore.text = score.ToString();

            if (score > bestScore)
            {
                bestScore = score;
                _bestScore.text = bestScore.ToString();
                SaveBestScoreToStorage();
            }
        }

        public int GetBestScoreFromStorage()
        {
            return PlayerPrefs.GetInt("BestScore", 0);
        }

        private void SaveBestScoreToStorage()
        {
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }
}