using System.Collections.Generic;
using Shop;
using UI;
using UI.Models;
using UnityEngine;

namespace Playable.Interactions
{
    public class ShopInteraction : MonoBehaviour, IInteractionEvent
    {
        [SerializeField] private Store store;
        [SerializeField] private List<ItemModelSo> items;
        
        private List<ItemModelSo> _itemsSelected = new List<ItemModelSo>();
        
        private UIFacade _uiFacade;

        public void OnInteraction(Player.Player player)
        {
            _uiFacade = ShopServiceLocator.Instance.Get<UIFacade>();
            _uiFacade.OpenShop(items, store.itemsToBuy, OnShop, OnClose, OnBuy);
        }

        private void OnBuy()
        {
            _uiFacade.CloseView();
            _uiFacade.ShowPopUp("Added Items", "Items Added Success", "shop");
            store.itemsToBuy.AddRange(items);
            _itemsSelected.Clear();
        }

        private void OnClose()
        {
            _uiFacade.CloseView();
            _itemsSelected.Clear();
        }

        private void OnShop(List<ItemModelSo> itemsSelected)
        {
            _itemsSelected = new List<ItemModelSo>(itemsSelected);
        }
    }
}