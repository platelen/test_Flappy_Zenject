using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _gravity = -10f;
        [SerializeField] private float _strengthSpace = 5f;

        private Vector3 _directaion;

        private void Update()
        {
            InputControllerPC();
            InputControllerMobile();

            _directaion.y += _gravity * Time.deltaTime;
            transform.position += _directaion * Time.deltaTime;
        }

        private void InputControllerPC()
        {
            if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0)))
            {
                _directaion = Vector3.up * _strengthSpace;
            }
        }

        private void InputControllerMobile()
        {
            // Проверяем наличие нажатия на экран
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _directaion = Vector3.up * _strengthSpace;
                }
            }
        }
    }
}