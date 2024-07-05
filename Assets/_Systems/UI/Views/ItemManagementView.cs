using UnityEngine;
using TMPro;

namespace UI.Views
{
    public class ItemManagementView : BaseView
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