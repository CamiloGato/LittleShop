using UnityEngine;
using UnityEngine.Events;

namespace UI.Models
{
    [CreateAssetMenu(menuName = "Player/Create Player Wallet", fileName = "PlayerWalletModelSo", order = 0)]
    public class PlayerWalletModelSo : ScriptableObject
    {
        public UnityEvent<int> onWalletMoneyChanged;
        
        [SerializeField] private string walletAddress;
        [SerializeField] private int walletMoney;

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
    }
}