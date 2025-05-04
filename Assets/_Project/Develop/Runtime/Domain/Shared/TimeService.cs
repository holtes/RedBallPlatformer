using UnityEngine;

namespace _Project.Develop.Runtime.Domain.Shared
{
    public class TimeService
    {
        public float DeltaTime => Time.deltaTime;
        public float TimeSinceStartup => Time.realtimeSinceStartup;

        public TimeService()
        {
            Time.timeScale = 1;
        }

        public void PauseTime()
        {
            Time.timeScale = 0f;
        }

        public void ContinueTime()
        {
            Time.timeScale = 1;
        }
    }
}