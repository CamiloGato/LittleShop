using Shop;
using Shop.Trade;
using UI;
using UI.Models;
using UnityEngine;

namespace Playable.Interactions
{
    public class ShopSellInteraction : MonoBehaviour, IInteractionEvent
    {
        [SerializeField] private Store store;
        
        private UIFacade _uiFacade;
        private Player.Player _player;
        private CartModelSo _playerCartModel;
        
        public void OnInteraction(Player.Player player)
        {
            _playerCartModel = player.cartModel;
            _playerCartModel.ClearKart();
            _player = player;
            _uiFacade = ServiceLocator.Instance.Get<UIFacade>();
            
            _uiFacade.OpenShop(
                "Available","Sell",
                _player.playerInfoModel.playerInventoryModel.Items,
                OnSell, OnClose, OnUse
            );
            
        }

        private void OnUse()
        {
            // TODO: Check if items are equipped using an specific Id
            // foreach (ItemModelSo item in _playerCartModel.Items)
            // {
            //     if (_player.playerClothesModel.HasItem(item))
            //     {
            //         _uiFacade.ShowPopUp(
            //             "Error Sell",
            //             "You can not sell items that are equipped",
            //             "bad"
            //         );
            //         return;
            //     };
            // }
            
            TradeService tradingService = ServiceLocator.Instance.Get<TradeService>();
            TradeHistory success = tradingService.Trade(_player, store, _playerCartModel.Items);
            if (success != null)
            {
                // TODO: No use hard coded values
                _uiFacade.ShowPopUp(
                    "Success Sell",
                    $"You sold {success.items.Count} items for ${success.transactionHistory.amount}",
                    "good"
                );
                
                _playerCartModel.ClearKart();
            }
            else
            {
                _uiFacade.ShowPopUp(
                    "Error Sell",
                    "You could not sell this items",
                    "bad"
                );
            }
        }

        private void OnClose()
        {
            
        }

        private void OnSell(ItemModelSo item)
        {
            if (_playerCartModel.Items.Contains(item))
            {
                _playerCartModel.RemoveItem(item);
                _uiFacade.ShowPopUp("Item Removed", $"{item.itemName} removed", "bad");
            }
            else
            {
                _playerCartModel.AddItem(item);
                _uiFacade.ShowPopUp("Item Added", $"{item.itemName} added", "good");
            }
        }
    }
}