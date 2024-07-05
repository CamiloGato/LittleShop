using System.Collections.Generic;
using Shop.Trade;
using UnityEngine;

namespace Shop.Economy
{
    [CreateAssetMenu(menuName = "Economy/Create WalletDataSo", fileName = "WalletDataSo", order = 0)]
    public class WalletDataSo : ScriptableObject
    {
        public string walletName;
        public int walletMoney;
        public List<TradeRegistry> trades;
        
        public void AddTrade(TradeRegistry trade)
        {
            trades.Add(trade);
        }
        
        public void AddMoney(int money)
        {
            walletMoney += money;
        }
        
        public void RemoveMoney(int money)
        {
            walletMoney -= money;
        }
        
    }
}