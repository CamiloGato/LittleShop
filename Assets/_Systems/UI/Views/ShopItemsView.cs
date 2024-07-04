using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class ShopItemsView : BaseView
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TMP_Text titleText;
        
        public override void Initialize()
        {
            canvasGroup.alpha = 1;
        }

        public override void Close()
        {
            canvasGroup.alpha = 0;
        }
        
        public void SetTitle(string title)
        {
            titleText.text = title;
        }
        
    }
}