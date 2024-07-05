using TMPro;
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

        public void UpdateTime(int hours, int minutes)
        {
            string time = $"{hours:00}:{minutes:00}";
            timeText.text = time;
        }
        
        public void UpdateTimeSky(Sprite skySprite, Sprite sunSprite)
        {
            skyImage.sprite = skySprite;
            sunImage.sprite = sunSprite;
        }
        
    }
}