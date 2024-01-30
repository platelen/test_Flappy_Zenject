using TMPro;
using UnityEngine;

namespace GameOver
{
    public class ScoringAfterGameOver:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private TextMeshProUGUI _bestScore;

        // Счет уже сохраненный, храните его где-то в игре
        private int bestScore;

        private void Start()
        {
            bestScore = GetBestScoreFromStorage(); // Загрузите лучший счет из сохраненных данных
            _bestScore.text = bestScore.ToString();
        }

        public void Scoring(int score)
        {
            _currentScore.text = score.ToString();

            if (score > bestScore)
            {
                bestScore = score;
                _bestScore.text = bestScore.ToString();
                SaveBestScoreToStorage(); // Сохраните новый лучший счет
            }
        }

        public int GetBestScoreFromStorage()
        {
            // Здесь вам нужно реализовать получение лучшего счета из сохраненных данных (например, из PlayerPrefs)
            // Пример:
            return PlayerPrefs.GetInt("BestScore", 0);
        }

        private void SaveBestScoreToStorage()
        {
            // Здесь вам нужно реализовать сохранение лучшего счета в сохраненных данных
            // Пример:
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }
}