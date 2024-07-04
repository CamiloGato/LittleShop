using UI.Components;
using UI.Models;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class PlayerInfoController : BaseController<PlayerInfoView>
    {
        [Header("Components")]
        [SerializeField] private PlayerImageComponent playerImageComponent;
        [SerializeField] private TimeStampComponent timeStampComponent;
        
        public override void Initialize()
        {
            base.Initialize();
        }
        
        public override void Close()
        {
            base.Close();
        }

        #region Methods
        
        public void SetPlayerModel(PlayerImageModel playerModel)
        {
            playerImageComponent.SetPlayerModel(playerModel);
        }
        
        public void UpdatePlayerView()
        {
            playerImageComponent.UpdatePlayerView(0);
        }
        
        public void UpdateTimeState(TimeStateModel timeState)
        {
            timeStampComponent.UpdateTime(timeState);
        }
        
        public void UpdatePlayerInfo(PlayerInfoModel playerInfo)
        {
            baseView.SetPlayerInfo(playerInfo.playerName, playerInfo.playerMoney);
        }
        
        #endregion
    }
}