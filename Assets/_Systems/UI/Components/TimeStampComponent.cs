using TMPro;
using UI.Models;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class TimeStampComponent : BaseComponent
    {
        [Header("Images")]
        [SerializeField] private Image skyImage;
        [SerializeField] private Image sunImage;
        [SerializeField] private TMP_Text timeText;
        
        public override void Initialize() { }

        public override void Close() { }

        public void UpdateTime(TimeStateModel timeState)
        {
            skyImage.sprite = timeState.skySprite;
            sunImage.sprite = timeState.sunSprite;
            (int hours, int minutes) = GetTime(timeState.currentTime);
            timeText.text = $"{hours}:{minutes}";
        }

        public (int, int) GetTime(float totalSeconds)
        {
            int hours = (int)totalSeconds / 3600;
            int minutes = (int)(totalSeconds - hours * 3600) / 60;
            return (hours, minutes);
        }
        
    }
}