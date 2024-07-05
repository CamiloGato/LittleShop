using Shop;
using Shop.Economy;
using Shop.Inventory;
using Shop.Trade;
using Timer;
using UI;
using UnityEngine;

namespace Manager
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private UIFacade uiFacade;
        [SerializeField] private TimeManager timeManager;
        
        private void Awake()
        {
            RegisterShopServices();
        }

        private void RegisterShopServices()
        {
            ShopServiceLocator.Instance.Register<IEconomyService>(new TransactionEconomyService());
            ShopServiceLocator.Instance.Register<IInventoryService>(new EntityInventoryService());
            ShopServiceLocator.Instance.Register<TradeService>(new TradeService());
        }
    }
}