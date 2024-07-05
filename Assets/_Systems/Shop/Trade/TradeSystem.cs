using System;
using System.Collections.Generic;
using Shop.Economy;
using Shop.Inventory;
using Shop.Items;
using UI;
using UnityEngine;

namespace Shop.Trade
{
    public class TradeSystem : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private UIFacade uiFacade;
        [SerializeField] private EconomySystem economySystem;
        [SerializeField] private InventorySystem inventorySystem;
        
        public TradeRegistry CreateSell(TradeEntity tradeFrom, TradeEntity tradeTo, List<ItemMetaData> items)
        {
            if (items.Count == 0) return null;
            
            
            WalletDataSo walletFrom = tradeFrom.walletDataSo;
            WalletDataSo walletTo = tradeTo.walletDataSo;
            
            InventoryDataSo inventoryFrom = tradeFrom.inventoryDataSo;
            InventoryDataSo inventoryTo = tradeTo.inventoryDataSo;
            
            inventorySystem.TradeItem(inventoryFrom, inventoryTo, items);
            int totalAmount = economySystem.TransferMoney(walletFrom, walletTo, items);

            TradeRegistry tradeRegistry = new TradeRegistry()
            {
                tradeId = Guid.NewGuid().ToString(),
                items = items,
                tradeEntityFrom = tradeFrom.tradeEntityMeta,
                tradeEntityTo = tradeTo.tradeEntityMeta,
                totalAmount = totalAmount
            };
            
            return tradeRegistry;
        }

        public void TradeWith(TradeEntity from, TradeEntity tradeTo)
        {
            uiFacade.OpenShopPanel(
                from.walletDataSo.walletMoney,
                tradeTo.inventoryDataSo.items,
                () =>
                {
                    
                }
            );
        }
        
    }
}