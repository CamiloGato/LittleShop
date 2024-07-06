using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Views
{
    public class SideMenuView : BaseView
    {
        [Header("Buttons")]
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        [SerializeField] private Button useButton;
        [SerializeField] private Button backButton;
        
        [Header("Text")]
        [SerializeField] private TMP_Text useButtonText;
        [SerializeField] private TMP_Text backButtonText;

        [Header("Events")]
        public UnityEvent leftButtonEvent;
        public UnityEvent rightButtonEvent;
        public UnityEvent useButtonEvent;
        public UnityEvent backButtonEvent;

        public override void Initialize()
        {
            base.Initialize();
            leftButton.onClick.AddListener(LeftButton);
            rightButton.onClick.AddListener(RightButton);
            useButton.onClick.AddListener(UseButton);
            backButton.onClick.AddListener(BackButton);
        }

        public override void Close()
        {
            base.Close();
            leftButton.onClick.RemoveAllListeners();
            rightButton.onClick.RemoveAllListeners();
            useButton.onClick.RemoveAllListeners();
            backButton.onClick.RemoveAllListeners();
        }

        private void LeftButton()
        {
            leftButtonEvent?.Invoke();
        }

        private void RightButton()
        {
            rightButtonEvent?.Invoke();
        }
        
        private void UseButton()
        {
            useButtonEvent?.Invoke();
        }

        private void BackButton()
        {
            backButtonEvent?.Invoke();
        }

        public void SetUseButtonText(string text)
        {
            useButtonText.text = text;
        }
        
        public void SetBackButtonText(string text)
        {
            backButtonText.text = text;
        }
    }
}