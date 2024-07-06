using System.Collections.Generic;
using Shop;
using Shop.Economy;
using Shop.Inventory;
using Shop.Trade;
using Storage;
using UI;
using UI.Models;
using UnityEngine;

namespace Manager
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private UIFacade uiFacade;
        [SerializeField] private TimeManager timeManager;
        [SerializeField] private PlayerInfoModelSo playerInfoModel;
        [SerializeField] private DataConfiguration dataConfiguration;
        
        public List<ItemModelSo> items;

        private void Start()
        {
            RegisterShopServices();
        }

        private void RegisterShopServices()
        {
            ServiceLocator.Instance.Register<IEconomyService>(new TransactionEconomyService());
            ServiceLocator.Instance.Register<IInventoryService>(new EntityInventoryService());
            ServiceLocator.Instance.Register<TradeService>(new TradeService());
            ServiceLocator.Instance.Register<UIFacade>(uiFacade);
            ServiceLocator.Instance.Register<TimeManager>(timeManager);
            ServiceLocator.Instance.Register<DataConfiguration>(dataConfiguration);
        }
        
        private void OnShop(List<ItemModelSo> listItems)
        {
            foreach (ItemModelSo itemModelSo in listItems)
            {
                if (itemModelSo is ClothModelSo clothes)
                {
                    Debug.Log($"Buy Clothes: {clothes.name}");
                }
                else
                {
                    Debug.Log($"Buy Item: {itemModelSo.itemName}");
                }
            }
        }
    }
}