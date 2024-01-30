using Events;
using GameOver;
using Pipes;
using TMPro;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabPlayer;
        [SerializeField] private Transform _startPosPlayer;
        [SerializeField] private GameObject _panelMainMenu;
        [SerializeField] private GameObject _backgroundColorBlack;
        [SerializeField] private TextMeshProUGUI _textScore;
        [SerializeField] private GameObject _panelGameOver;
        [SerializeField] private GameObject _buttonPause;
        [SerializeField] private ScoringAfterGameOver _scoringAfterGameOver;

        private int _score;
        private bool _isGameOver;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            Pause();
            TriggerEvents.OnStartGameOver.AddListener(GameOver);
            TriggerEvents.OnStartAddScore.AddListener(IncreaseScore);
        }

        private void Start()
        {
            _panelGameOver.SetActive(false);
        }

        private void Update()
        {
            _textScore.text = _score.ToString();
        }

        private void GameOver()
        {
            _isGameOver = true;
            _textScore.enabled = false;
            _backgroundColorBlack.SetActive(true);
            _panelGameOver.SetActive(true);
            _buttonPause.SetActive(false);
            _scoringAfterGameOver.Scoring(_score);
            Pause();
        }

        private void IncreaseScore()
        {
            _score++;
        }

        public void Play()
        {
            _isGameOver = false;

            _backgroundColorBlack.SetActive(false);
            _panelMainMenu.SetActive(false);
            Time.timeScale = 1f;
            PauseEvent.SendStartGame();
        }

        public void Pause()
        {
            if (_isGameOver)
            {
                PauseEvent.SendStartPause();
                _backgroundColorBlack.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                PauseEvent.SendStartPause();
                _backgroundColorBlack.SetActive(true);
                _panelMainMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        public void RepeatGame()
        {
            _isGameOver = false;
            MovedPipes[] pipes = FindObjectsOfType<MovedPipes>();
            for (int i = 0; i < pipes.Length; i++)
            {
                Destroy(pipes[i].gameObject);
            }

            SpawnPlayerAfterRepeatGame();
            _textScore.enabled = true;
            _score = 0;
            _buttonPause.SetActive(true);
            _backgroundColorBlack.SetActive(false);
            _panelMainMenu.SetActive(false);
            _panelGameOver.SetActive(false);
            Time.timeScale = 1f;
            _scoringAfterGameOver.GetBestScoreFromStorage();
            PauseEvent.SendStartGame();
            RepeatGameEvent.SendStartRepeatGame();
        }

        private void SpawnPlayerAfterRepeatGame()
        {
            Instantiate(_prefabPlayer, _startPosPlayer.position, Quaternion.identity);
        }
    }
}