using System;
using UI.Models;

namespace Shop.Economy
{
    [Serializable]
    public class Transaction
    {
        public PlayerWalletModelSo from;
        public PlayerWalletModelSo to;
        public int amount;
        public string time;

        public bool CanExecute()
        {
            return from.HasEnoughMoney(amount);
        }
        
    }
}