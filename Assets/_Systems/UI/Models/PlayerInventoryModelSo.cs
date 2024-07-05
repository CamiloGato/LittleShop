﻿using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(menuName = "Player/Create Player Inventory", fileName = "PlayerInventoryModelSo", order = 0)]
    public class PlayerInventoryModelSo : ScriptableObject
    {
        [SerializeField] private List<ItemModelSo> items;
        
        public bool HasItem(ItemModelSo item)
        {
            return items.Contains(item);
        }
        
        public void AddItem(ItemModelSo item)
        {
            items.Add(item);
        }

        public void RemoveItem(ItemModelSo item)
        {
            items.Remove(item);
        }
    }
}