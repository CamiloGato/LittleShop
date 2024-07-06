using Playable.Player;
using Shop;
using Shop.Trade;
using UI;
using UI.Models;
using UnityEngine;

namespace Playable.Interactions
{
    public class ShopPayInteraction : MonoBehaviour, IInteractionEvent
    {
        [SerializeField] private Store store;
        
        private UIFacade _uiFacade;
        
        private Player.Player _player;
        private CartModelSo _playerCartModel;
        
        public void OnInteraction(Player.Player player)
        {
            _player = player;
            _playerCartModel = player.cartModel;
            
            _uiFacade = ServiceLocator.Instance.Get<UIFacade>();
            _uiFacade.OpenShop(
                "Cart", "Buy" ,
                _playerCartModel.Items,
                OnShop, OnClose, OnBuy, _ => true
            );
        }

        private void OnBuy()
        {
            PlayerInteraction.CanInteract = true;
            
            TradeService tradingService = ServiceLocator.Instance.Get<TradeService>();
            // Before buying, we need to fill the items to buy | Unlimited Store Items
            store.FillItemsToBuy(_playerCartModel.Items);
            TradeHistory success = tradingService.Trade(store, _player, _playerCartModel.Items);
            if (success != null)
            {
                // TODO: No use hard coded values
                _uiFacade.ShowPopUp(
                    "Success Shop",
                    $"You bought {success.items.Count} items for {success.transactionHistory.amount}",
                    "shop"
                );
            }
            else
            {
                _uiFacade.ShowPopUp(
                    "Error Shop",
                    "You can not buy this item",
                    "error"
                );
            }

            _playerCartModel.ClearKart();
        }

        private void OnClose()
        {
            
        }

        private void OnShop(ItemModelSo item)
        {
            if (_playerCartModel.Items.Contains(item))
            {
                _playerCartModel.RemoveItem(item);
                _uiFacade.ShowPopUp("Item Removed", $"{item.itemName} removed", "shop");
            }
            else
            {
                _playerCartModel.AddItem(item);
                _uiFacade.ShowPopUp("Item Added", $"{item.itemName} added", "shop");
            }
        }
    }
}