using System;
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
        [SerializeField] private PlayerImageModel playerRenderView;
        [SerializeField] private PlayerInfoModel playerInfoView;
        [SerializeField] private PopUpModel popUpView;
        [SerializeField] private ItemModel shopItemView;
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
        
        
        
        #endregion
        
    }
}