﻿using UI.Components;
using UI.Controllers;
using UI.Models;
using UnityEngine;

namespace UI
{
    public class UIFacade : MonoBehaviour
    {
        [Header("Controllers")]
        [SerializeField] private PlayerInfoController playerInfoController;
        [SerializeField] private PlayerRenderController playerRenderController;
        [SerializeField] private PopUpController popUpController;
        [SerializeField] private ShopItemsController shopItemsController;
        [SerializeField] private ShopTransactionController shopTransactionController;
        [Space]
        
        [Header("Data")]
        [SerializeField] private PlayerImageModel playerImageModel;
        [SerializeField] private PlayerInfoModel playerInfoModel;
        [SerializeField] private PopUpModel popUpModel;
        [SerializeField] private ItemModel shopItemModel;
        [SerializeField] private ClothModel shopClothModel;
        [SerializeField] private float time;

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Close();
        }

        public void Initialize()
        {
            playerInfoController.Initialize();
            playerRenderController.Initialize();
            popUpController.Initialize();
            shopItemsController.Initialize();
            shopTransactionController.Initialize();
            
            shopItemsController.selectedItemEvent.AddListener(OnShopItemSelected);
        }

        public void Close()
        {
            playerInfoController.Close();
            playerRenderController.Close();
            popUpController.Close();
            shopItemsController.Close();
            shopTransactionController.Close();
        }
        
        #region Methods

        /// <summary>
        /// Update the player info view: UserName and Money
        /// </summary>
        [ContextMenu("Update Player Info")]
        public void UpdatePlayerInfo()
        {
            playerInfoController.UpdatePlayerInfo(playerInfoModel);
        }

        /// <summary>
        /// Update the time view: Sky and Sun - Time
        /// </summary>
        [ContextMenu("Update Time")]
        public void UpdateTime()
        {
            playerInfoController.UpdateTime(time);
        }

        /// <summary>
        /// Update the player render view: PlayerImage
        /// </summary>
        [ContextMenu("Update Player Image")]
        public void UpdatePlayerImage()
        {
            playerInfoController.UpdatePlayerView(playerImageModel);
            playerRenderController.UpdatePlayerView(playerImageModel);
        }
        
        [ContextMenu("Add Pop Up")]
        public void AddPopUp()
        {
            popUpController.AddPopUp(popUpModel);
        }
        
        [ContextMenu("Add Shop Item")]
        public void AddShopItem()
        {
            shopItemsController.AddItem(shopItemModel);
        }
        
        [ContextMenu("Add Shop Cloth")]
        public void AddShopCloth()
        {
            shopItemsController.AddItem(shopClothModel);
        }
        
        private void OnShopItemSelected(ShopItemComponent itemComponent)
        {
            ItemModel itemModel = itemComponent.ItemModel;
            if (itemModel is ClothModel clothModel)
            {
                playerRenderController.UpdatePlayerClothView(clothModel);
            }
            else
            {
                playerRenderController.UpdatePlayerItemView(itemComponent.ItemModel);
            }
        }

        public void RemoveItem(ShopItemComponent itemComponent)
        {
            shopItemsController.RemoveItem(itemComponent);
        }
        
        #endregion
        
    }
}