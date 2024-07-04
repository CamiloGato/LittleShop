using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Views
{
    public class ShopTransactionView : BaseView
    {
        [Header("Canvas")]
        [SerializeField] private CanvasGroup canvasGroup;
        
        [Header("Buttons")]
        [SerializeField] private Button backButton;
        [SerializeField] private Button transactionButton;
        
        [Header("Texts")]
        [SerializeField] private Text transactionText;
        
        public UnityEvent backButtonEvent;
        public UnityEvent transactionButtonEvent;
        
        public override void Initialize()
        {
            canvasGroup.alpha = 1;
            
            backButton.onClick.AddListener(
                () => backButtonEvent?.Invoke()    
            );
            
            transactionButton.onClick.AddListener(
                () => transactionButtonEvent?.Invoke()    
            );
        }

        public override void Close()
        {
            canvasGroup.alpha = 0;
        }
        
        public void SetTransactionText(string text)
        {
            transactionText.text = text;
        }
    }
}