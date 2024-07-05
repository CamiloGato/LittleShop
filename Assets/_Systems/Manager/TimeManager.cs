using UI.Models;
using UnityEngine;

namespace Manager
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        public TimeStampModelSo timeStampModel;
        [SerializeField] private float timeSpeed;
        private float _currentTime;

        public void Update()
        {
            _currentTime += Time.deltaTime * timeSpeed;
            if (_currentTime > timeStampModel.MaxTime)
            {
                _currentTime = 0;
            }
            timeStampModel.CurrentTime = _currentTime;
        }
    }
}