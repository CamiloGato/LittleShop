using UnityEngine;
using UI.Views;
using UI.Models;
using System.Collections.Generic;
using UI.Components;
using UI.Components.Pool;
using UnityEngine.Events;

namespace UI.Controllers
{
    public class ItemManagementController : BaseController<ItemManagementView>
    {
        [Header("Section Group")]
        [SerializeField] private RectTransform sectionGroup;
     
        [Header("Components Prefab")]
        [SerializeField] private ItemComponent itemComponentPrefab;
        
        [Header("Events")]
        public UnityEvent<ItemComponent> selectedItemEvent;

        /// Item Pool
        private ComponentPool<ItemComponent> _itemPool;
        
        private List<ItemComponent> _selectedItems = new();
        public List<ItemModelSo> SelectedItemsModels => _selectedItems.ConvertAll(item => item.ItemModel);

        public override void Initialize()
        {
            base.Initialize();
            InitializeComponents();
            InitializeEvents();
        }

        public override void Close()
        {
            base.Close();
            _itemPool.Clear();
            selectedItemEvent.RemoveAllListeners();
        }

        private void InitializeComponents()
        {
            _itemPool = new ComponentPool<ItemComponent>(itemComponentPrefab, sectionGroup);
            _selectedItems = new List<ItemComponent>();
        }

        private void InitializeEvents()
        {
            selectedItemEvent = new UnityEvent<ItemComponent>();
        }

        public void SetUp(string title)
        {
            baseView.SetTitle(title);
        }

        public void AddItem(ItemModelSo itemData)
        {
            var item = _itemPool.Get();
            item.Initialize();
            item.AddCallback(SelectedItem);
            item.SetItem(itemData);
        }

        public void AddItem(List<ItemModelSo> items)
        {
            foreach (var itemData in items)
            {
                AddItem(itemData);
            }
        }

        public void RemoveItem(ItemComponent item)
        {
            item.Close();
            _itemPool.ReturnToPool(item);
        }

        public void UpdateList()
        {
            foreach (var item in _itemPool.ActivePool)
            {
                item.ButtonStatus(1 > item.ItemModel.value);
            }
        }

        private void SelectedItem(ItemComponent item)
        {
            CheckSelectedItem(item);
            selectedItemEvent?.Invoke(item);
        }

        private void CheckSelectedItem(ItemComponent item)
        {
            bool isSelected = _selectedItems.Contains(item);
            item.SetSelected(isSelected);
        }
    }
}
