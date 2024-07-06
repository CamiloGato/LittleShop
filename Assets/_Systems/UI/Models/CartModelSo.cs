using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    
    [CreateAssetMenu(menuName = "Shop/Create Cart", fileName = "CartModelSo", order = 0)]
    public class CartModelSo : ScriptableObject
    {
        [SerializeField] private List<ItemModelSo> items = new List<ItemModelSo>();
        public List<ItemModelSo> Items => items;
        
        public void AddItem(ItemModelSo item)
        {
            items.Add(item);
        }

        public void RemoveItem(ItemModelSo item)
        {
            items.Remove(item);
        }

        public void ClearKart()
        {
            items.Clear();
        }
    }
}