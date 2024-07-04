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
        
        public override void Initialize()
        {
            base.Initialize();
            _currentLook = 0;
            
            baseView.leftButtonEvent.AddListener(NextView);
            baseView.rightButtonEvent.AddListener(PrevView);
        }
        
        public override void Close()
        {
            base.Close();
            baseView.leftButtonEvent.RemoveAllListeners();
            baseView.rightButtonEvent.RemoveAllListeners();
        }

        #region Methods
        
        public void SetPlayerModel(PlayerImageModel playerModel)
        {
            playerImageComponent.SetPlayerModel(playerModel);
        }

        public void UpdatePlayerView()
        {
            playerImageComponent.UpdatePlayerView(_currentLook);
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