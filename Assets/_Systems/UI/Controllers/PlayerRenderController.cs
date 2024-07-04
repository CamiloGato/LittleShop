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
        
        public override void Initialize()
        {
            base.Initialize();
            baseView.leftButtonEvent.AddListener(NextView);
            baseView.rightButtonEvent.AddListener(PrevView);
        }
        
        public override void Close()
        {
            base.Close();
            baseView.leftButtonEvent.RemoveAllListeners();
            baseView.rightButtonEvent.RemoveAllListeners();
        }

        public void SetPlayerModel(PlayerImageModel playerModel)
        {
            playerImageComponent.SetPlayerModel(playerModel);
        }
        
        #region Events
        private int _currentLook;
        
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