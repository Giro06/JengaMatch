using System;
using UnityEngine;

namespace Quok
{
    public struct Timer
    {
        private float _duration;
        private float _timer;
        private bool _firstCompleteFlag;

        public event Action CompletedEvent;
        public float NormalizedTime => Mathf.Min(1, _timer / _duration);

        public float NormalizedTimePingPong
        {
            get
            {
                float t = Mathf.Min(1, _timer / _duration);
                if (t < 0.5f)
                {
                    return t * 2;
                }
                return (1 - t) * 2;
            }
        }
        public bool Done => _timer >= _duration;
        public float Duration => _duration;
        public float Time => _timer;

        public Timer(float duration)
        {
            this._duration = duration;
            _timer = 0;
            _firstCompleteFlag = false;
            CompletedEvent = null;
        }

        public void Restart()
        {
            _timer = 0;
            _firstCompleteFlag = false;
        }

        public void Restart(float newDuration)
        {
            _duration = newDuration;
            Restart();
        }

        public bool Update(float deltaTime)
        {
            _timer += deltaTime;
            if (_timer >= _duration)
            {
                _timer = _duration;
                if (!_firstCompleteFlag)
                {
                    _firstCompleteFlag = true;
                    CompletedEvent?.Invoke();
                }
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return _timer + "/" + _duration;
        }

        public string TimeToText()
        {
            return TimeSpan.FromSeconds(_timer).ToString("mm':'ss");
        }

        public string LeftTimeToText()
        {
            float time = _duration - _timer;
            return TimeSpan.FromSeconds(time).ToString("mm':'ss");
        }
    }
}