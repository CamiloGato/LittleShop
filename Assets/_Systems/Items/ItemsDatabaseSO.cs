using System.Collections.Generic;
using Items.Models;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Items/ItemsDataBaseSO", fileName = "ItemsDatabaseSO", order = 0)]
    public class ItemsDatabaseSO : ScriptableObject
    {
        public List<ItemMono> items;

        public ItemMono GetItem(string itemName)
        {
            return items.Find(x => x.data.name == itemName);
        }

        public ItemMono GetItem(ItemDataSO itemData)
        {
            return items.Find(x => x.data == itemData);
        }
    }
}