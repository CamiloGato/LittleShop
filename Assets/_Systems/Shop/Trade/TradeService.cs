using System.Collections.Generic;
using Manager;
using Shop.Economy;
using Shop.Inventory;
using UI.Models;

namespace Shop.Trade
{
    public class TradeService
    {
        private readonly IEconomyService _economyService = ShopServiceLocator.Instance.Get<IEconomyService>();
        private readonly IInventoryService _inventoryService = ShopServiceLocator.Instance.Get<IInventoryService>();
        
        public TradeHistory Trade(TradeEntity from, TradeEntity to, List<ItemModelSo> items)
        {
            PlayerWalletModelSo fromWallet = from.playerInfoModel.playerWalletModel;
            PlayerWalletModelSo toWallet = to.playerInfoModel.playerWalletModel;
            
            PlayerInventoryModelSo fromInventory = from.playerInfoModel.playerInventoryModel;
            PlayerInventoryModelSo toInventory = to.playerInfoModel.playerInventoryModel;
            
            BillHistory transactionHistory = _economyService.CreateTransaction(fromWallet, toWallet);
            InventoryHistory inventoryHistory = _inventoryService.CreateInventoryHistory(fromInventory, toInventory);
            
            foreach (ItemModelSo item in items)
            {
                _economyService.AddItem(transactionHistory, item);
                _inventoryService.AddItem(inventoryHistory, item);
            }
            
            bool billSuccess = _economyService.ExecuteTransaction(transactionHistory);

            if (!billSuccess)
            {
                return null;
            }
            
            bool inventorySuccess = _inventoryService.ExecuteReplace(inventoryHistory);
            
            if (!inventorySuccess)
            {
                return null;
            }
            
            TimeManager timeManager = ShopServiceLocator.Instance.Get<TimeManager>();
            
            TradeHistory history = new TradeHistory()
            {
                transactionHistory = transactionHistory,
                time = timeManager.timeStampModel.TimeString,
                items = items
            };
            
            from.playerInfoModel.playerWalletModel.AddTradeHistory(history);
            to.playerInfoModel.playerWalletModel.AddTradeHistory(history);
            
            return history;
        }
    }
}