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
        private UnityEvent<ItemModelSo> _selectedItemEvent;
        
        private ComponentPool<ItemComponent> _itemPool;
        
        [SerializeField] private List<ItemComponent> selectedItems = new List<ItemComponent>();
        public List<ItemModelSo> SelectedItemsModels => selectedItems.ConvertAll(item => item.ItemModel);

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
            _selectedItemEvent.RemoveAllListeners();
        }

        private void InitializeComponents()
        {
            _itemPool = new ComponentPool<ItemComponent>(itemComponentPrefab, sectionGroup);
            selectedItems = new List<ItemComponent>();
        }

        private void InitializeEvents()
        {
            _selectedItemEvent = new UnityEvent<ItemModelSo>();
        }

        public void SetUp(string title)
        {
            baseView.SetTitle(title);
        }

        public void AddSelectedItemCallback(UnityAction<ItemModelSo> callback)
        {
            _selectedItemEvent.AddListener(callback);
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
            if (selectedItems.Contains(item))
            {
                selectedItems.Remove(item);
            }
            
            item.Close();
            _itemPool.ReturnToPool(item);
        }

        public void UpdateList(int amount)
        {
            foreach (var item in _itemPool.ActivePool)
            {
                item.ButtonStatus(amount > item.ItemModel.value);
            }
        }

        private void SelectedItem(ItemComponent item)
        {
            CheckSelectedItem(item);
            _selectedItemEvent?.Invoke(item.ItemModel);
        }

        private void CheckSelectedItem(ItemComponent item)
        {
            bool isSelected = selectedItems.Contains(item);

            if (!isSelected)
            {
                selectedItems.Add(item);
            }
            else
            {
                selectedItems.Remove(item);
            }
            
            item.SetSelected(!isSelected);
        }
    }
}
