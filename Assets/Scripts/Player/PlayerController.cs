using UnityEngine;
using Events;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _gravity = -10f;
        [SerializeField] private float _strengthSpace = 5f;

        private Vector3 _directaion;

        private void Awake()
        {
            PauseEvent.OnStartPause.AddListener(DisablePlayer);
            PauseEvent.OnStartGame.AddListener(EnablePlayer);
            TriggerEvents.OnStartGameOver.AddListener(DisablePlayer);
        }

        private void Update()
        {
            InputControllerPC();
            InputControllerMobile();

            _directaion.y += _gravity * Time.deltaTime;
            transform.position += _directaion * Time.deltaTime;
        }

        private void InputControllerPC()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _directaion = Vector3.up * _strengthSpace;
            }
        }

        private void InputControllerMobile()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _directaion = Vector3.up * _strengthSpace;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Obstacle")
            {
                Destroy(gameObject);
                TriggerEvents.SendStartGameOver();
            }

            if (other.gameObject.tag == "Score_Line")
            {
                TriggerEvents.SendStartAddScore();
            }
        }

        private void EnablePlayer()
        {
            enabled = true;
        }

        private void DisablePlayer()
        {
            enabled = false;
        }
    }
}