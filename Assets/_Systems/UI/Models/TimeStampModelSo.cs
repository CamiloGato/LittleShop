using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Models
{
    [Serializable]
    public class TimeSkySunModel
    {
        [Range(0, 24)] public int hourRise;
        public Sprite skySprite;
        public Sprite sunSprite;
    }
 
    [Serializable]
    public class TimeSkyList
    {
        public List<TimeSkySunModel> timeSkySunModels;
        
        public (Sprite, Sprite) GetTimeSkySun(int hour)
        {
            int count = timeSkySunModels.Count;
            
            if (count == 0) return (null, null);

            for (int i = 0; i < count; i++)
            {
                TimeSkySunModel currentModel = timeSkySunModels[i];
                TimeSkySunModel nextModel = timeSkySunModels[(i + 1) % count];

                int currentHourRise = currentModel.hourRise;
                int nextHourRise = nextModel.hourRise;
                
                if (
                    (currentHourRise <= hour && hour < nextHourRise)
                    || (currentHourRise <= hour && nextHourRise == 0)
                    || (currentHourRise > nextHourRise && (hour >= currentHourRise || hour < nextHourRise))
                    )
                {
                    return (currentModel.skySprite, currentModel.sunSprite);
                }
            }

            throw new Exception("Invalid Hour unexpected");
        }
    }
    
    [CreateAssetMenu(menuName = "Time/Create Time Image", fileName = "TimeImageModelSo", order = 0)]
    public class TimeStampModelSo : ScriptableObject
    {
        public UnityEvent<int, int> onTimeChange;
        public UnityEvent<Sprite, Sprite> onTimeSkyChange;
        
        [SerializeField] private TimeSkyList timeSkyList;
        [Range(0, 1440)]
        [SerializeField] private float currentTime;

        private bool _isInitialized;
        private int _currentHours, _currentMinutes;
        public float CurrentTime
        {
            get => currentTime;
            set
            {
                currentTime = value;
                
                int hours = (int)currentTime / 60;
                int minutes = (int)currentTime % 60;

                if (hours == _currentHours && minutes == _currentMinutes) return;
                
                if (hours != _currentHours || !_isInitialized)
                {
                    _isInitialized = true;
                    var (skySprite, sunSprite) = timeSkyList.GetTimeSkySun(hours);
                    onTimeSkyChange?.Invoke(skySprite, sunSprite);
                }
                
                _currentMinutes = minutes;
                _currentHours = hours;
                onTimeChange?.Invoke(hours, minutes);
            }
        }
    }
}