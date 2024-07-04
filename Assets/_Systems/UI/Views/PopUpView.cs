using UnityEngine;

namespace UI.Views
{
    public class PopUpView : BaseView
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup canvasGroup;

        public override void Initialize()
        {
            canvasGroup.alpha = 1;
        }

        public override void Close()
        {
            canvasGroup.alpha = 0;
        }
    }
}