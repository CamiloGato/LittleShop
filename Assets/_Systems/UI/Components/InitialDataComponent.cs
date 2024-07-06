using Shop;
using TMPro;
using UI.Models;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class InitialDataComponent : BaseComponent
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Graphic backgroundImage;
        
        [Header("Input Fields")]
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private TMP_InputField initialMoneyInputField;
        [SerializeField] private Button createButton;
        
        [Header("Data")]
        public PlayerInfoModelSo playerInfoModel;
        
        public override void Initialize()
        {
            Playable.Player.PlayerInteraction.CanInteract = false;
            
            backgroundImage.gameObject.SetActive(true);
            
            backgroundImage.CrossFadeAlpha(1, 0f, true);
            canvasGroup.alpha = 1;
            
            createButton.onClick.AddListener(OnCreate);
        }

        private void OnCreate()
        {
            UIFacade uiFacade = ServiceLocator.Instance.Get<UIFacade>();
            
            string playerName = nameInputField.text;
            if (playerName.Length == 0)
            {
                uiFacade.ShowPopUp(
                    "Error Create",
                    "You must enter a name",
                    "bad"
                );
                return;
            }

            int money = GetMoney(initialMoneyInputField.text);
            if (money <= 0)
            {
                uiFacade.ShowPopUp(
                    "Error Create",
                    "You must enter an initial money",
                    "bad"
                );
                return;
            }

            playerInfoModel.ChangeName(playerName);
            playerInfoModel.playerWalletModel.SetBalance(money);
            
            uiFacade.ShowPopUp(
                "Success Create",
                $"You created a new player {playerName}",
                "good"
            );
            uiFacade.ShowPopUp(
                "Success Create",
                $"You have ${money} in your wallet",
                "good"
            );
            
            Close();
        }

        private int GetMoney(string text)
        {
            return int.TryParse(text, out var money) ? money : 0;
        }

        public override void Close()
        {
            Playable.Player.PlayerInteraction.CanInteract = true;
            
            backgroundImage.CrossFadeAlpha(0, 0.5f, true);
            canvasGroup.alpha = 0;
            
            Invoke(nameof(Exit), 0.5f);
            
            createButton.onClick.RemoveListener(OnCreate);
        }
        
        public void Exit()
        {
            backgroundImage.gameObject.SetActive(false);
        }
        
    }
}