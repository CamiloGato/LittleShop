using UnityEngine;
using TMPro;

namespace UI.Views
{
    public class TopMenuView : BaseView
    {
        [Header("Texts")]
        [SerializeField] private TMP_Text playerNameText;
        [SerializeField] private TMP_Text playerMoneyText;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Close()
        {
            base.Close();
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