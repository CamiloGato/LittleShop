using System.Collections.Generic;
using Shop.Items;
using UnityEngine;

namespace Shop.Economy
{
    public class EconomySystem : MonoBehaviour
    {
        public int TransferMoney(WalletDataSo from, WalletDataSo to, int money)
        {
            from.RemoveMoney(money);
            to.AddMoney(money);
            
            return money;
        }
        
        public int TransferMoney(WalletDataSo from, WalletDataSo to, List<ItemMetaData> items)
        {
            var totalTransfer = 0;
            foreach (ItemMetaData itemMetaData in items)
            {
                totalTransfer += TransferMoney(from, to, itemMetaData.value);
            }
            
            return totalTransfer;
        }
        
    }
}