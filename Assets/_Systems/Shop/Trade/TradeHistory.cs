using System;
using System.Collections.Generic;
using Shop.Economy;
using UI.Models;

namespace Shop.Trade
{
    [Serializable]
    public class TradeHistory
    {
        public BillHistory transactionHistory;
        public string time;
        public List<ItemModelSo> items;
    }
}