using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class ObjectNotificationComponent : BaseComponent
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text notificationText;
        
        public override void Initialize()
        {
            image.gameObject.SetActive(true);
        }

        public override void Close()
        {
            image.gameObject.SetActive(false);
        }

        public void SetText(string text)
        {
            notificationText.text = text;
        }
    }
}