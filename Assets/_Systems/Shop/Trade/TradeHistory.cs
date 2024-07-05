using System;
using System.Collections.Generic;
using UI.Models;

namespace Shop.Trade
{
    [Serializable]
    public class TradeHistory
    {
        public PlayerWalletModelSo fromWallet;
        public PlayerWalletModelSo toWallet;
        public List<ItemModelSo> items;
    }
}