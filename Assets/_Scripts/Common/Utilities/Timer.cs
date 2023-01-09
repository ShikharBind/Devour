using UnityEngine;

namespace GameDev.Common
{
    public class Timer
    {
        private float totalTime;
        private float currTime;
        public bool isTimeUp { get { return (currTime == 0); } }
        public bool isExpired = false;

        public Timer(float duration)
        {
            totalTime = duration;
            Reset();
        }

        public void Reset()
        {
            currTime = totalTime;
            isExpired = false;
        }

        public void Update(float deltaTime)
        {
            if (!isExpired)
            {
                if (currTime > 0) currTime -= deltaTime;
                else currTime = 0;
            }
        }

        public void Expire()
        {
            isExpired = true;
            currTime = -1;
        }
    }
}