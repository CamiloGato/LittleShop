using UI.Components;
using UnityEngine;
using UI.Views;
using UI.Models;
using UnityEngine.Events;

namespace UI.Controllers
{
    public class SideMenuController : BaseController<SideMenuView>
    {
        [Header("Components")]
        [SerializeField] private PlayerImageComponent playerImageComponent;

        [Header("Data")]
        [SerializeField] private PlayerClothesModelSo playerClothesModel;
        
        [Header("Events")]
        [SerializeField] private UnityEvent useButtonEvent;
        [SerializeField] private UnityEvent backButtonEvent;
        
        private int _currentLook;

        public override void Initialize()
        {
            base.Initialize();
            InitializeComponents();
            InitializeEvents();
        }

        public override void Close()
        {
            base.Close();
            playerImageComponent.Close();
            ClearEvents();
        }
        
        public void SetButtonText(string useButton, string backButton)
        {
            baseView.SetUseButtonText(useButton);
            baseView.SetBackButtonText(backButton);
        }
        
        public void AddButtonsCallback(UnityAction useButton, UnityAction backButton)
        {
            useButtonEvent.AddListener(useButton);
            backButtonEvent.AddListener(backButton);
        }

        private void InitializeComponents()
        {
            _currentLook = 0;
            playerImageComponent.Initialize();
            playerImageComponent.SetUpPlayer(playerClothesModel.clothes, playerClothesModel.item);
        }

        private void InitializeEvents()
        {
            baseView.leftButtonEvent.AddListener(NextView);
            baseView.rightButtonEvent.AddListener(PrevView);
            baseView.useButtonEvent.AddListener(UseButton);
            baseView.backButtonEvent.AddListener(BackButton);
            
            playerClothesModel.onClothesChanged.AddListener(UpdatePlayerView);
            playerClothesModel.onItemChanged.AddListener(UpdatePlayerView);
        }
        
        private void ClearEvents()
        {
            baseView.leftButtonEvent.RemoveAllListeners();
            baseView.rightButtonEvent.RemoveAllListeners();
            baseView.useButtonEvent.RemoveAllListeners();
            baseView.backButtonEvent.RemoveAllListeners();
            
            useButtonEvent.RemoveAllListeners();
            backButtonEvent.RemoveAllListeners();
        }

        private void UpdatePlayerView(ClothModelSo cloth)
        {
            playerImageComponent.UpdatePlayerCloth(cloth);
        }
        
        private void UpdatePlayerView(ItemModelSo item)
        {
            playerImageComponent.UpdatePlayerItem(item);
        }
        
        private void PrevView()
        {
            _currentLook = (_currentLook - 1 + 4) % 4;
            playerImageComponent.UpdatePlayerView(_currentLook);
        }

        private void NextView()
        {
            _currentLook = (_currentLook + 1) % 4;
            playerImageComponent.UpdatePlayerView(_currentLook);
        }
        
        private void UseButton()
        {
            useButtonEvent?.Invoke();
        }

        private void BackButton()
        {
            backButtonEvent?.Invoke();
        }
    }
}
