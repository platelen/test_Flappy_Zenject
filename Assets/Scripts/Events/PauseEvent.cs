using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class PauseEvent : MonoBehaviour
    {
        public static readonly UnityEvent OnStartPause = new UnityEvent();
        public static readonly UnityEvent OnStartGame = new UnityEvent();

        public static void SendStartPause()
        {
            OnStartPause.Invoke();
        }

        public static void SendStartGame()
        {
            OnStartGame.Invoke();
        }
    }
}