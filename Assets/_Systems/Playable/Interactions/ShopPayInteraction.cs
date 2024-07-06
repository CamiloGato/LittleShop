using System.Collections.Generic;
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
        private List<ItemModelSo> _itemsSelected = new List<ItemModelSo>();
        private Player.Player _player;
        
        public void OnInteraction(Player.Player player)
        {
            _itemsSelected = new List<ItemModelSo>(store.itemsToBuy);
            _player = player;
            
            _uiFacade = ShopServiceLocator.Instance.Get<UIFacade>();
            _uiFacade.OpenShop(store.itemsToBuy, store.itemsToBuy, OnShop, OnClose, OnBuy);
        }

        private void OnBuy()
        {
            PlayerInteraction.CanInteract = true;
            _uiFacade.CloseView();
            
            TradeService tradingService = ShopServiceLocator.Instance.Get<TradeService>();
            // Before buying, we need to fill the items to buy | Unlimited Store Items
            store.FillItemsToBuy();
            TradeHistory success = tradingService.Trade(store, _player, _itemsSelected);
            if (success != null)
            {
                _uiFacade.ShowPopUp("Success", "You bought " + success.items.Count + " items", "shop");
            }
            else
            {
                _uiFacade.ShowPopUp("Error", "You don't have enough money", "shop");
            }
        }

        private void OnClose()
        {
            _itemsSelected.Clear();
            _uiFacade.CloseView();
        }

        private void OnShop(List<ItemModelSo> items)
        {
            _itemsSelected = new List<ItemModelSo>(items);
        }
    }
}