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
        
        public List<ItemModelSo> items;
        
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                uiFacade.Close();
            }
            
            if (Input.GetKeyDown(KeyCode.P))
            {
                uiFacade.OpenShop(items, OnShop);
            }
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