using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Views
{
    public class PlayerRenderView : BaseView
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Buttons")]
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [Header("Events")] [Space]
        public UnityEvent leftButtonEvent;
        public UnityEvent rightButtonEvent;
        
        public override void Initialize()
        {
            canvasGroup.alpha = 1;
            
            leftButton.onClick.AddListener(
                () => leftButtonEvent?.Invoke()
            );
            rightButton.onClick.AddListener(
                () => rightButtonEvent?.Invoke()
            );
        }

        public override void Close()
        {
            canvasGroup.alpha = 0;
            
            leftButton.onClick.RemoveAllListeners();
            rightButton.onClick.RemoveAllListeners();
        }
        
    }
}