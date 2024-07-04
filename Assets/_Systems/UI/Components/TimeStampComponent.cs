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
        
        [Header("Data")]
        [SerializeField] private TimeImageModel timeImage;
        
        public override void Initialize() { }

        public override void Close() { }

        public void UpdateTimeImage(int hours)
        {
            (Sprite skySprite, Sprite sunSprite) = timeImage.GetTimeSkySun(hours);
            
            skyImage.sprite = skySprite;
            sunImage.sprite = sunSprite;
        }

        public void UpdateTime(int hours, int minutes)
        {
            string time = $"{hours:00}:{minutes:00}";
            timeText.text = time;
        }
        
    }
}