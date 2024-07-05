using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Views
{
    public class SideMenuView : BaseView
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Buttons")]
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [Header("Events")]
        public UnityEvent leftButtonEvent;
        public UnityEvent rightButtonEvent;

        public override void Initialize()
        {
            canvasGroup.alpha = 1;
            leftButton.onClick.AddListener(LeftButton);
            rightButton.onClick.AddListener(RightButton);
        }

        public override void Close()
        {
            canvasGroup.alpha = 0;
            leftButton.onClick.RemoveAllListeners();
            rightButton.onClick.RemoveAllListeners();
        }

        private void LeftButton()
        {
            leftButtonEvent?.Invoke();
        }

        private void RightButton()
        {
            rightButtonEvent?.Invoke();
        }
    }
}