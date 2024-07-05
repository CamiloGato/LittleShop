using System.Collections.Generic;
using Shop.Items;
using UnityEngine;

namespace Shop.Inventory
{
    [CreateAssetMenu(menuName = "Items/Create InventoryDataSo", fileName = "InventoryDataSo", order = 0)]
    public class InventoryDataSo : ScriptableObject
    {
        public string inventoryName;
        public List<ItemDataSo> items;
        
        public ItemDataSo GetItem(ItemMetaData itemMetaData)
        {
            foreach (ItemDataSo item in items)
            {
                if (item.itemMetaData.Equals(itemMetaData))
                {
                    return item;
                }
            }
            return null;
        }
        
        public void AddItem(ItemDataSo item)
        {
            items.Add(item);
        }
        
        public void RemoveItem(ItemDataSo item)
        {
            items.Remove(item);
        }
    }
}