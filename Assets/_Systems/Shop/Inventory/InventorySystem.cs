using System.Collections.Generic;
using Shop.Items;
using UnityEngine;

namespace Shop.Inventory
{
    public class InventorySystem : MonoBehaviour
    {
        
        public void TradeItem(InventoryDataSo inventoryFrom, InventoryDataSo inventoryTo, ItemMetaData itemMetaData)
        {
            ItemDataSo item = inventoryFrom.GetItem(itemMetaData);
            
            inventoryFrom.RemoveItem(item);
            inventoryTo.AddItem(item);
        }
        
        public void TradeItem(InventoryDataSo inventoryFrom, InventoryDataSo inventoryTo, List<ItemMetaData> items)
        {
            foreach (ItemMetaData itemMetaData in items)
            {
                TradeItem(inventoryFrom, inventoryTo, itemMetaData);
            }
        }
        
        public void AddItem(InventoryDataSo inventory, ItemDataSo item)
        {
            inventory.AddItem(item);
        }
        
        public void RemoveItem(InventoryDataSo inventory, ItemDataSo item)
        {
            inventory.RemoveItem(item);
        }

        public void AddItemList(InventoryDataSo inventory, List<ItemDataSo> items)
        {
            foreach (ItemDataSo item in items)
            {
                inventory.AddItem(item);
            }
        }
        
    }
}