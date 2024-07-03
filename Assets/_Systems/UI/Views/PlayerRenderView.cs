using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Views
{
    public class PlayerRenderView : BaseView
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup canvasGroup;
        
        [Header("Images")]
        [SerializeField] private Image basePlayer;
        [SerializeField] private Image outPlayer;
        [SerializeField] private Image harPlayer;
        [SerializeField] private Image hatPlayer;
        
        [Header("Buttons")]
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        public UnityEvent leftButtonEvent;
        public UnityEvent rightButtonEvent;
        
        public override void Initialize()
        {
            canvasGroup.alpha = 0;
            
            leftButton.onClick.AddListener(
                () => leftButtonEvent?.Invoke()
            );
            rightButton.onClick.AddListener(
                () => rightButtonEvent?.Invoke()
            );
        }

        public override void Close()
        {
            canvasGroup.alpha = 1;
            
            leftButton.onClick.RemoveAllListeners();
            rightButton.onClick.RemoveAllListeners();
        }

        #region Change Sprites Methods
        public void ChangeBasePlayer(Sprite sprite)
        {
            basePlayer.sprite = sprite;
        }
        
        public void ChangeOutPlayer(Sprite sprite)
        {
            outPlayer.sprite = sprite;
        }
        
        public void ChangeHarPlayer(Sprite sprite)
        {
            harPlayer.sprite = sprite;
        }
        
        public void ChangeHatPlayer(Sprite sprite)
        {
            hatPlayer.sprite = sprite;
        }
        #endregion
        
        
    }
}