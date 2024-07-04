using UI.Components;
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
        
        [Header("Section Group")]
        [SerializeField] private RectTransform sectionGroup;
        
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
        }
        
        #region Methods
        public void AddItem(ItemModel itemData)
        {
            ShopItemComponent item = _itemPool.Get();
            item.Initialize();
            item.SetItem(itemData);
        }

        public void RemoveItem(ShopItemComponent item)
        {
            item.Close();
            _itemPool.ReturnToPool(item);
        }
        #endregion
    }
}