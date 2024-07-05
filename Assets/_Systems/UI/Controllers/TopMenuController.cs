using UI.Components;
using UI.Components.Pool;
using UnityEngine;
using UI.Models;
using UI.Views;
using UnityEngine.Events;

namespace UI.Controllers
{
    public class TopMenuController : BaseController<TopMenuView>
    {
        [Header("Components")]
        [SerializeField] private PlayerImageComponent playerImageComponent;
        [SerializeField] private TimeStampComponent timeStampComponent;
        
        [Header("Data")]
        [SerializeField] private PlayerInfoModelSo playerInfoModel;
        [SerializeField] private TimeStampModelSo timeStampModel;

        [Header("Prefabs")]
        [SerializeField] private MoneyDifferenceComponent moneyDifferenceComponent;
        [SerializeField] private RectTransform sectionGroup;

        [Header("Events")]
        [SerializeField] private UnityEvent<MoneyDifferenceComponent> finishAnimationEvent;

        private ComponentPool<MoneyDifferenceComponent> _moneyDifferencePool;
        private int _currentMoney;

        public override void Initialize()
        {
            base.Initialize();
            InitializeComponents();
            InitializeEvents();
        }

        public override void Close()
        {
            base.Close();
            _moneyDifferencePool.Clear();
            
            playerImageComponent.Close();
            timeStampComponent.Close();
        }

        private void InitializeComponents()
        {
            _moneyDifferencePool = new ComponentPool<MoneyDifferenceComponent>(moneyDifferenceComponent, sectionGroup, 3);
            
            playerImageComponent.Initialize();
            timeStampComponent.Initialize();
        }

        private void InitializeEvents()
        {
            finishAnimationEvent = new UnityEvent<MoneyDifferenceComponent>();
            
            finishAnimationEvent.AddListener(FinishAnimation);
            playerInfoModel.onPlayerInfoChanged.AddListener(UpdatePlayerInfo);
            timeStampModel.onTimeChange.AddListener(UpdateTime);
            timeStampModel.onTimeSkyChange.AddListener(UpdateTimeSky);
        }

        private void UpdatePlayerInfo(string playerName, int playerMoney)
        {
            baseView.SetPlayerInfo(playerName, playerMoney);
            UpdateMoneyDifference(playerMoney);
        }

        private void UpdateTime(int hours, int minutes)
        {
            timeStampComponent.UpdateTime(hours, minutes);
        }

        private void UpdateTimeSky(Sprite skySprite, Sprite sunSprite)
        {
            timeStampComponent.UpdateTimeSky(skySprite, sunSprite);
        }

        private void UpdateMoneyDifference(int newMoney)
        {
            int difference = newMoney - _currentMoney;
            _currentMoney = newMoney;

            if (difference == 0) return;

            var component = _moneyDifferencePool.Get();
            component.Initialize();
            component.SetCallback(finishAnimationEvent);
            component.SetDifference(difference);
        }

        private void FinishAnimation(MoneyDifferenceComponent data)
        {
            data.Close();
            _moneyDifferencePool.ReturnToPool(data);
        }
    }
}
