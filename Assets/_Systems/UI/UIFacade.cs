using System;
using UnityEngine;
using UI.Models;
using System.Collections.Generic;
using Playable.Player;
using UI.Controllers;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class UIFacade : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] private ItemManagementController itemManagementController;
        [SerializeField] private TopMenuController topMenuController;
        [SerializeField] private SideMenuController sideMenuController;
        [SerializeField] private PopUpController popUpController;
        
        [Header("Data")]
        [SerializeField] private IconConfigSo iconConfig;

        [SerializeField] private Graphic backgroundImage;
        [SerializeField] private float fadeDuration = 0.5f;
        
        private void OnEnable()
        {
            Initialize();
            CloseView();
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
        }

        private void Close()
        {
            itemManagementController.Close();
            topMenuController.Close();
            sideMenuController.Close();
        }

        public void CloseView()
        {
            PlayerInteraction.CanInteract = true;
            backgroundImage.CrossFadeAlpha(0, fadeDuration, false);
            itemManagementController.Close();
            sideMenuController.Close();
        }

        public void OpenShop(
            string itemsTitle, string buttonTitle,
            List<ItemModelSo> items,
            UnityAction<ItemModelSo> callback,
            UnityAction onClose,
            UnityAction onUse,
            Func<ItemModelSo, bool> validateItemSelection = null)
        {
            PlayerInteraction.CanInteract = false;
            backgroundImage.CrossFadeAlpha(1, fadeDuration, false);
            
            sideMenuController.Initialize();
            sideMenuController.SetButtonText(buttonTitle, "Back");
            sideMenuController.AddButtonsCallback(
                () =>
                {
                    onUse?.Invoke();
                },
                () =>
                {
                    onClose?.Invoke();
                    CloseView();
                }
            );
            
            bool SelectedCondition(ItemModelSo item) => validateItemSelection?.Invoke(item) ?? false;
            
            itemManagementController.Initialize();
            itemManagementController.SetUp($"Shop | {itemsTitle}");
            itemManagementController.AddItem(items, SelectedCondition);
            itemManagementController.AddSelectedItemCallback(
                item =>
                {
                    if (item is ClothModelSo cloth)
                    {
                        sideMenuController.UpdatePlayerView(cloth);
                    }
                    else
                    {
                        sideMenuController.UpdatePlayerView(item);
                    }
                    callback?.Invoke(item);
                }
            );
        }

        public void OpenInventory(List<ItemModelSo> items)
        {
        }

        public void OpenSell(List<ItemModelSo> items, UnityAction<ItemModelSo> callback)
        {
        }
        
        public void ShowPopUp(string title, string message, string icon)
        {
            Sprite iconSprite = iconConfig.GetIcon(icon);
            PopUpModel model = new PopUpModel()
            {
                title = title,
                description = message,
                icon = iconSprite
            };
            
            popUpController.AddPopUp(model);
        }
    }
}
