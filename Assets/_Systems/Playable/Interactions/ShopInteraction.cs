﻿using System.Collections.Generic;
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
        
        private UIFacade _uiFacade;
        private CartModelSo _playerCartModel;
        
        public void OnInteraction(Player.Player player)
        {
            _uiFacade = ServiceLocator.Instance.Get<UIFacade>();
            _playerCartModel = player.cartModel;
            _uiFacade.OpenShop(
                "Available","Add Cart",
                items,
                OnShop, OnClose, OnBuy, ValidateItemSelection
            );
        }

        private bool ValidateItemSelection(ItemModelSo item)
        {
            return _playerCartModel.Items.Contains(item);
        }

        private void OnBuy()
        {
            
        }

        private void OnClose()
        {
            
        }

        private void OnShop(ItemModelSo itemsSelected)
        {
            if (_playerCartModel.Items.Contains(itemsSelected))
            {
                _playerCartModel.RemoveItem(itemsSelected);
                _uiFacade.ShowPopUp("Item Removed", $"{itemsSelected.itemName} removed", "shop");
            }
            else
            {
                _playerCartModel.AddItem(itemsSelected);
                _uiFacade.ShowPopUp("Item Added", $"{itemsSelected.itemName} added", "shop");
            }
        }
    }
}