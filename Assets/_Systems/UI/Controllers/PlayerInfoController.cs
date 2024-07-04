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
        
        public override void Initialize()
        {
            base.Initialize();
        }
        
        public override void Close()
        {
            base.Close();
        }

        public void SetPlayerModel(PlayerImageModel playerModel)
        {
            playerImageComponent.SetPlayerModel(playerModel);
        }
        
        public void UpdatePlayerView()
        {
            playerImageComponent.UpdatePlayerView(0);
        }
        
        public void UpdatePlayerInfo(PlayerInfoModel playerInfo)
        {
            baseView.SetPlayerInfo(playerInfo.playerName, playerInfo.playerMoney);
        }
        
        public void UpdateTimeState(TimeStateModel timeState)
        {
            baseView.SetTimeState(timeState.timeSprite, timeState.currentTime);
        }
        
    }
}