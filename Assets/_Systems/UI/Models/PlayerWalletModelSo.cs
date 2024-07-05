using System;
using System.Collections.Generic;
using Shop.Trade;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Models
{
    [CreateAssetMenu(menuName = "Player/Create Player Wallet", fileName = "PlayerWalletModelSo", order = 0)]
    public class PlayerWalletModelSo : ScriptableObject
    {
        public UnityEvent<int> onWalletMoneyChanged;
        public UnityEvent<TradeHistory, string> onTradeHistoryChanged;
        
        [SerializeField] private string walletAddress;
        [SerializeField] private int walletMoney;
        [SerializeField] private List<TradeHistory> tradeHistory;

        public void SetBalance(int balance)
        {
            walletMoney = balance;
            onWalletMoneyChanged?.Invoke(walletMoney);
        }
        
        public void AddMoney(int amount)
        {
            walletMoney += amount;
            onWalletMoneyChanged?.Invoke(walletMoney);
        }
        
        public void RemoveMoney(int amount)
        {
            walletMoney -= amount;
            onWalletMoneyChanged?.Invoke(walletMoney);
        }

        public bool HasEnoughMoney(int amount)
        {
            return walletMoney >= amount;
        }
        
        public void AddTradeHistory(TradeHistory history)
        {
            string boughtOrSold = history.fromWallet == this ? "Bought" : "Sold";
            tradeHistory.Add(history);
            onTradeHistoryChanged?.Invoke(history, boughtOrSold);
        }
        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            onWalletMoneyChanged.Invoke(walletMoney);
        }
        #endif
        
    }
}