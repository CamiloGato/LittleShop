using UI.Models;
using UnityEngine;

namespace Timer
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private TimeStampModelSo timeStampModel;
        [SerializeField] private float timeSpeed;
        private float _currentTime;

        public void Update()
        {
            _currentTime += Time.deltaTime * timeSpeed;
            // TODO: Set as global configuration
            _currentTime = Mathf.Clamp(_currentTime, 0, 1440);
            timeStampModel.CurrentTime = _currentTime;
        }
    }
}