using UI.Components;
using UI.Components.Pool;
using UI.Models;
using UI.Views;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Controllers
{
    public class PlayerInfoController : BaseController<PlayerInfoView>
    {
        [Header("Components")]
        [SerializeField] private PlayerImageComponent playerImageComponent;
        [SerializeField] private TimeStampComponent timeStampComponent;
        
        [Header("Prefabs")]
        [SerializeField] private MoneyDifferenceComponent moneyDifferenceComponent;
        [SerializeField] private RectTransform sectionGroup;
        
        [Header("Data")]
        [SerializeField] private TimeImageModel timeImage;
        
        [Header("Events")] [Space]
        [SerializeField] private UnityEvent<MoneyDifferenceComponent> finishAnimationEvent;
        
        private ComponentPool<MoneyDifferenceComponent> _moneyDifferencePool;
        
        private int _currentMoney;
        
        public override void Initialize()
        {
            base.Initialize();
            
            _moneyDifferencePool = new ComponentPool<MoneyDifferenceComponent>(moneyDifferenceComponent, sectionGroup);
            
            finishAnimationEvent = new UnityEvent<MoneyDifferenceComponent>();
            finishAnimationEvent.AddListener(FinishAnimation);
            
            playerImageComponent.Initialize();
            timeStampComponent.Initialize();
        }

        public override void Close()
        {
            base.Close();
            
            _moneyDifferencePool.Clear();
            
            playerImageComponent.Close();
            timeStampComponent.Close();
        }

        #region Methods
        
        public void SetPlayerImageModel(PlayerImageModel playerModel)
        {
            playerImageComponent.SetPlayerModel(playerModel);
        }
        
        public void UpdatePlayerView()
        {
            playerImageComponent.UpdatePlayerView(0);
        }
        
        public void UpdateTimeState(float time)
        {
            int hours = (int) time / 60;
            int minutes = (int) time % 60;

            Sprite skySprite = hours < 12 ? timeImage.skyDaySprite : timeImage.skyNightSprite;
            Sprite sunSprite = hours < 12 ? timeImage.sunDaySprite : timeImage.sunNightSprite;
         
            timeStampComponent.UpdateTime(hours, minutes);
            timeStampComponent.UpdateTimeImage(skySprite, sunSprite);
        }
        
        public void UpdatePlayerInfo(PlayerInfoModel playerInfo)
        {
            baseView.SetPlayerInfo(playerInfo.playerName, playerInfo.playerMoney);
            
            int difference = playerInfo.playerMoney - _currentMoney;
            _currentMoney = playerInfo.playerMoney;

            if (difference == 0) return;
            
            MoneyDifferenceComponent component = _moneyDifferencePool.Get();
            component.Initialize();
            component.SetCallback(finishAnimationEvent);
            component.SetDifference(difference);
        }
        
        #endregion
        
        private void FinishAnimation(MoneyDifferenceComponent data)
        {
            data.Close();
            _moneyDifferencePool.ReturnToPool(data);
        }
    }
}