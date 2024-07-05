using UI.Models;
using UnityEngine;

namespace Shop.Trade
{
    public class TradeEntity : MonoBehaviour
    {
        public PlayerInfoModelSo playerInfoModel;
        
        public PlayerInventoryModelSo Inventory => playerInfoModel.playerInventoryModel;
        public PlayerWalletModelSo Wallet => playerInfoModel.playerWalletModel;
    }
}