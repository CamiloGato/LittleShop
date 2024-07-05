using UnityEngine;
using UI.Models;
using System.Collections.Generic;
using UI.Controllers;
using UnityEngine.Events;

namespace UI
{
    public class UIFacade : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] private ItemManagementController itemManagementController;
        [SerializeField] private TopMenuController topMenuController;
        [SerializeField] private SideMenuController sideMenuController;
        [SerializeField] private PopUpController popUpController;

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
            itemManagementController.Initialize();
            topMenuController.Initialize();
            sideMenuController.Initialize();
            popUpController.Initialize();
            
            popUpController.AddPopUp(new PopUpModel()
            {
                title = "Welcome",
                description = "Welcome to Little Shop",
                icon = null
            });
        }

        public void Close()
        {
            itemManagementController.Close();
            topMenuController.Close();
            sideMenuController.Close();
            popUpController.Close();
        }

        public void OpenShop(List<ItemModelSo> items, UnityAction<List<ItemModelSo>> callback)
        {
            itemManagementController.SetUp("Shop");
            itemManagementController.AddItem(items);
            itemManagementController.selectedItemEvent.AddListener((item) =>
            {
                List<ItemModelSo> selectedItems = itemManagementController.SelectedItemsModels;
                callback?.Invoke(selectedItems);
            });
        }

        public void OpenInventory(List<ItemModelSo> items)
        {
            itemManagementController.SetUp("Inventory");
            itemManagementController.AddItem(items);
        }

        public void OpenSell(List<ItemModelSo> items, UnityAction<List<ItemModelSo>> callback)
        {
            itemManagementController.SetUp("Sell");
            itemManagementController.AddItem(items);
            itemManagementController.selectedItemEvent.AddListener((item) =>
            {
                List<ItemModelSo> selectedItems = itemManagementController.SelectedItemsModels;
                callback?.Invoke(selectedItems);
            });
        }
        
        public void ShowPopUp(string title, string message, Sprite icon)
        {
            PopUpModel model = new PopUpModel()
            {
                title = title,
                description = message,
                icon = icon
            };
            
            popUpController.AddPopUp(model);
        }
    }
}
