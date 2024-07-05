using System.Collections.Generic;
using Shop.Economy;
using Shop.Inventory;
using UI.Models;

namespace Shop.Trade
{
    public class TradeService
    {
        private readonly IEconomyService _economyService = ShopServiceLocator.Instance.Get<IEconomyService>();
        private readonly IInventoryService _inventoryService = ShopServiceLocator.Instance.Get<IInventoryService>();
        
        public bool Trade(TradeEntity from, TradeEntity to, ItemModelSo item)
        {
            PlayerWalletModelSo fromWallet = from.playerInfoModel.playerWalletModel;
            PlayerWalletModelSo toWallet = to.playerInfoModel.playerWalletModel;
            
            PlayerInventoryModelSo fromInventory = from.playerInfoModel.playerInventoryModel;
            PlayerInventoryModelSo toInventory = to.playerInfoModel.playerInventoryModel;
            
            Transaction transaction = _economyService.CreateTransaction(fromWallet, toWallet, item.value);
            bool success = _economyService.ExecuteTransaction(transaction);

            if (success)
            {
                return _inventoryService.ReplaceItem(fromInventory, toInventory, item);
            }
            
            return false;
        }

        public bool Trade(TradeEntity from, TradeEntity to, List<ItemModelSo> items)
        {
            foreach (ItemModelSo item in items)
            {
                if (!Trade(from, to, item)) return false;
            }
            
            return true;
        }
    }
}