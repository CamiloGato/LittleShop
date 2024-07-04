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
        
        public override void Initialize() { }

        public override void Close() { }

        public void UpdateTime(TimeStateModel timeState)
        {
            skyImage.sprite = timeState.skySprite;
            sunImage.sprite = timeState.sunSprite;
        }
        
    }
}