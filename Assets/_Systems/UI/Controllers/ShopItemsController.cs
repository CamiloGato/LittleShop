using Items.Models;
using UI.Components;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class ShopItemsController : BaseController<ShopItemsView>
    {
        [Header("Components Prefab")]
        [SerializeField] private ShopItemComponent shopItemComponent;
        
        [Header("Canvas Group")]
        [SerializeField] private RectTransform sectionGroup;
        
        public void AddItem(ItemDataSO itemData)
        {
            // TODO: Factory method for ShopItemComponent
            ShopItemComponent item = Instantiate(shopItemComponent, sectionGroup);
            item.SetItem(itemData);
        }
    }
}