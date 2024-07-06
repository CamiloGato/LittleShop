using System;
using UI.Models;

namespace Shop.Economy
{
    [Serializable]
    public class BillHistory
    {
        public PlayerWalletModelSo from;
        public PlayerWalletModelSo to;
        public int amount;

        public void AddItemPrice(int itemPrice)
        {
            amount += itemPrice;
        }
        
        public bool CanExecute()
        {
            return to.HasEnoughMoney(amount);
        }
        
    }
}