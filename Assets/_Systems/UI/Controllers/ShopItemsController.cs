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
        
        public override void Initialize()
        {
            base.Initialize();
            _itemPool = new ComponentPool<ShopItemComponent>(shopItemComponentPrefab, sectionGroup);
        }

        public override void Close()
        {
            base.Close();
            _itemPool.Clear();
            
            selectedItemEvent.RemoveAllListeners();
        }
        
        #region Methods
        public void SetTitle(string title)
        {
            baseView.SetTitle(title);
        }
        
        public void AddItem(ItemModel itemData)
        {
            ShopItemComponent item = _itemPool.Get();
            item.Initialize();
            item.AddCallback(SelectedItem);
            item.SetItem(itemData);
        }

        public void RemoveItem(ShopItemComponent item)
        {
            item.Close();
            _itemPool.ReturnToPool(item);
        }
        
        public void AddCallbackSelectedItem(UnityAction<ShopItemComponent> callback)
        {
            selectedItemEvent.AddListener(callback);
        }
        
        #endregion
        
        private void SelectedItem(ShopItemComponent item)
        {
            selectedItemEvent?.Invoke(item);
        }
    }
}