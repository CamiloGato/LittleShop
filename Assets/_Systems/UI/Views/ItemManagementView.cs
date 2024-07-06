using UnityEngine;
using TMPro;

namespace UI.Views
{
    public class ItemManagementView : BaseView
    {
        [Header("Texts")]
        [SerializeField] private TMP_Text titleText;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Close()
        {
            base.Close();
        }

        public void SetTitle(string title)
        {
            titleText.text = title;
        }
    }
}