using System;
using System.Collections.Generic;
using Shop;
using Shop.Economy;
using Shop.Inventory;
using Shop.Trade;
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
        
        public List<ItemModelSo> items;

        private void Start()
        {
            RegisterShopServices();
        }

        private void RegisterShopServices()
        {
            ShopServiceLocator.Instance.Register<IEconomyService>(new TransactionEconomyService());
            ShopServiceLocator.Instance.Register<IInventoryService>(new EntityInventoryService());
            ShopServiceLocator.Instance.Register<TradeService>(new TradeService());
            ShopServiceLocator.Instance.Register<UIFacade>(uiFacade);
            ShopServiceLocator.Instance.Register<TimeManager>(timeManager);
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