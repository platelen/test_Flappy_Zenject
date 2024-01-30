using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class RepeatGameEvent:MonoBehaviour
    {
        public static readonly UnityEvent OnStartRepeatGame = new UnityEvent();

        public static void SendStartRepeatGame()
        {
            OnStartRepeatGame.Invoke();
        }
    }
}