using UI.Components;
using UI.Models;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class PlayerRenderController : BaseController<PlayerRenderView>
    {
        [Header("Components")]
        [SerializeField] private PlayerImageComponent playerImageComponent;
        
        private int _currentLook;
        private PlayerImageModel _playerModel;
        
        public override void Initialize()
        {
            base.Initialize();
            _currentLook = 0;
            
            playerImageComponent.Initialize();
            
            baseView.leftButtonEvent.AddListener(NextView);
            baseView.rightButtonEvent.AddListener(PrevView);
        }
        
        public override void Close()
        {
            base.Close();
            
            playerImageComponent.Close();
            
            baseView.leftButtonEvent.RemoveAllListeners();
            baseView.rightButtonEvent.RemoveAllListeners();
        }

        #region Methods
        
        public void UpdatePlayerView(PlayerImageModel playerModel)
        {
            _playerModel = playerModel;
            
            playerImageComponent.SetPlayerModel(playerModel);
            playerImageComponent.UpdatePlayerView(_currentLook);
        }
        
        public void UpdatePlayerClothView(ClothModel clothModel)
        {
            _playerModel.ChangeClothLook(clothModel.clothImagePosture);
            playerImageComponent.UpdatePlayerClothView(clothModel);
        }
        
        public void UpdatePlayerItemView(ItemModel itemModel)
        {
            playerImageComponent.UpdatePlayerItemView(itemModel);
        }
        
        #endregion
        
        #region Events
        
        private void PrevView()
        {
            _currentLook--;
            _currentLook = _currentLook < 0 ? 3 : _currentLook;
            playerImageComponent.UpdatePlayerView(_currentLook);
        }

        private void NextView()
        {
            _currentLook++;
            _currentLook = _currentLook > 3 ? 0 : _currentLook;
            playerImageComponent.UpdatePlayerView(_currentLook);
        }
        #endregion
    }
}