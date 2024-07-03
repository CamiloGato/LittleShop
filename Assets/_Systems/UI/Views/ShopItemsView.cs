using UnityEngine;

namespace UI.Views
{
    public class ShopItemsView : BaseView
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup canvasGroup;
        
        public override void Initialize()
        {
            canvasGroup.alpha = 0;
        }

        public override void Close()
        {
            canvasGroup.alpha = 1;
        }
    }
}