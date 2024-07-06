using System;
using System.Collections.Generic;
using UI.Models;

namespace Shop.Inventory
{
    [Serializable]
    public class InventoryHistory
    {
        public PlayerInventoryModelSo from;
        public PlayerInventoryModelSo to;
        public List<ItemModelSo> items = new List<ItemModelSo>();
        
        public void AddItem(ItemModelSo item)
        {
            items.Add(item);
        }
        
        public bool CanExecute()
        {
            foreach (ItemModelSo item in items)
            {
                if (!from.HasItem(item)) return false;
            }
            
            return true;
        }
    }
}