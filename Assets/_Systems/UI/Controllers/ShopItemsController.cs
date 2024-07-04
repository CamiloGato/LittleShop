﻿using UI.Components;
using UI.Components.Pool;
using UI.Models;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class ShopItemsController : BaseController<ShopItemsView>
    {
        [Header("Components Prefab")]
        [SerializeField] private ShopItemComponent shopItemComponentPrefab;
        
        [Header("Canvas Group")]
        [SerializeField] private RectTransform sectionGroup;
        
        private ComponentPool<ShopItemComponent> _itemPool;
        
        public override void Initialize()
        {
            base.Initialize();
            _itemPool = new ComponentPool<ShopItemComponent>(shopItemComponentPrefab, sectionGroup);
        }

        #region Methods
        
        public void AddItem(ItemModel itemData)
        {
            ShopItemComponent item = _itemPool.Get();
            item.SetItem(itemData);
            item.Initialize();
        }

        public void RemoveItem(ShopItemComponent item)
        {
            item.Close();
            _itemPool.ReturnToPool(item);
        }
        
        #endregion
    }
}