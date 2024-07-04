using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class PlayerInfoView : BaseView
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TMP_Text playerNameText;
        [SerializeField] private TMP_Text playerMoneyText;
        [SerializeField] private Image timeImage;
        [SerializeField] private Text timeText;
        
        public override void Initialize()
        {
            canvasGroup.alpha = 1;
        }

        public override void Close()
        {
            canvasGroup.alpha = 0;
        }
        
        public void SetPlayerInfo(string playerName, int playerMoney)
        {
            playerNameText.text = playerName;
            playerMoneyText.text = playerMoney.ToString();
        }
    }
}