using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(menuName = "Player/Create Player Inventory", fileName = "PlayerInventoryModelSo", order = 0)]
    public class PlayerInventoryModelSo : ScriptableObject
    {
        private HashSet<ItemModelSo> _items = new HashSet<ItemModelSo>();
        
        public List<ItemModelSo> Items => _items.ToList();
        
        public bool HasItem(ItemModelSo item)
        {
            return _items.Contains(item);
        }
        
        public void AddItem(ItemModelSo item)
        {
            _items.Add(item);
        }
        
        public void AddItem(List<ItemModelSo> listItems)
        {
            foreach (ItemModelSo item in listItems)
            {
                AddItem(item);
            }
        }

        public void RemoveItem(ItemModelSo item)
        {
            _items.Remove(item);
        }
        
        public void RemoveItem(List<ItemModelSo> listItems)
        {
            foreach (ItemModelSo item in listItems)
            {
                RemoveItem(item);
            }
        }
    }
}