using System.Collections.Generic;
using System.Linq;
using UI.Components;
using UI.Components.Pool;
using UI.Models;
using UI.Views;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Controllers
{
    public class ShopItemsController : BaseController<ShopItemsView>
    {
        [Header("Components Prefab")]
        [SerializeField] private ShopItemComponent shopItemComponentPrefab;
        
        [Header("Section Group")]
        [SerializeField] private RectTransform sectionGroup;
        
        [Header("Events")] [Space]
        public UnityEvent<ShopItemComponent> selectedItemEvent;
        
        private ComponentPool<ShopItemComponent> _itemPool;
        
        private List<ShopItemComponent> _selectedItems = new List<ShopItemComponent>();
        public List<ItemModel> SelectedItems => _selectedItems.Select(item => item.ItemModel).ToList();
        private int _amount;
        
        
        public override void Initialize()
        {
            base.Initialize();
            _itemPool = new ComponentPool<ShopItemComponent>(shopItemComponentPrefab, sectionGroup);
            _selectedItems = new List<ShopItemComponent>();
        }

        public override void Close()
        {
            base.Close();
            _itemPool.Clear();
            
            selectedItemEvent.RemoveAllListeners();
        }
        
        #region Methods
        public void SetUp(string title, int amount)
        {
            baseView.SetTitle(title);
            _amount = amount;
        }
        
        public void AddItem(ItemModel itemData)
        {
            ShopItemComponent item = _itemPool.Get();
            item.Initialize();
            item.AddCallback(SelectedItem);
            item.SetItem(itemData);
        }

        public void AddItem(List<ItemModel> items)
        {
            foreach (ItemModel itemData in items)
            {
                AddItem(itemData);
            }
        }
        
        public void RemoveItem(ShopItemComponent item)
        {
            item.Close();
            _itemPool.ReturnToPool(item);
        }

        public void UpdateList()
        {
            foreach (ShopItemComponent item in _itemPool.ActivePool)
            {
                item.ButtonStatus(_amount > item.ItemModel.value);
            }
        }
        
        #endregion
        
        private void SelectedItem(ShopItemComponent item)
        {
            CheckSelectedItem(item);
            selectedItemEvent?.Invoke(item);
        }

        private void CheckSelectedItem(ShopItemComponent item)
        {
            bool isSelected = _selectedItems.Contains(item);
            item.SetSelected(isSelected);
            
            _amount = isSelected 
                ? _amount - item.ItemModel.value
                : _amount + item.ItemModel.value;
        }
    }
}