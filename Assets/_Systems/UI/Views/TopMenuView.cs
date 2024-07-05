using UnityEngine;
using TMPro;

namespace UI.Views
{
    public class TopMenuView : BaseView
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TMP_Text playerNameText;
        [SerializeField] private TMP_Text playerMoneyText;

        public override void Initialize()
        {
            canvasGroup.alpha = 1;
        }

        public override void Close()
        {
            canvasGroup.alpha = 0;
        }

        public void SetPlayerName(string playerName)
        {
            playerNameText.text = playerName;
        }
        
        public void SetPlayerMoney(int playerMoney)
        {
            playerMoneyText.text = $"$ {playerMoney:N0}";
        }
    }
}