using UI.Components;
using UnityEngine;
using UI.Views;
using UI.Models;

namespace UI.Controllers
{
    public class SideMenuController : BaseController<SideMenuView>
    {
        [Header("Components")]
        [SerializeField] private PlayerImageComponent playerImageComponent;

        [Header("Data")]
        [SerializeField] private PlayerClothesModelSo playerClothesModel;
        
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

        private void InitializeComponents()
        {
            _currentLook = 0;
            playerImageComponent.Initialize();
            playerImageComponent.SetPlayerCloth(playerClothesModel.clothes);
        }

        private void InitializeEvents()
        {
            baseView.leftButtonEvent.AddListener(NextView);
            baseView.rightButtonEvent.AddListener(PrevView);
            
            playerClothesModel.onClothesChanged.AddListener(UpdatePlayerView);
            playerClothesModel.onItemChanged.AddListener(UpdatePlayerView);
        }
        
        private void ClearEvents()
        {
            baseView.leftButtonEvent.RemoveAllListeners();
            baseView.rightButtonEvent.RemoveAllListeners();
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
    }
}
