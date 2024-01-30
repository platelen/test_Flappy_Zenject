using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class TriggerEvents:MonoBehaviour
    {
        public static readonly UnityEvent OnStartGameOver = new UnityEvent();
        public static readonly UnityEvent OnStartAddScore = new UnityEvent();
        
        public static void SendStartGameOver()
        {
            OnStartGameOver.Invoke();
        }
        public static void SendStartAddScore()
        {
            OnStartAddScore.Invoke();
        }
    }
}