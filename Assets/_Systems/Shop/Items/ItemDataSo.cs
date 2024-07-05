using UnityEngine;

namespace Shop.Items
{
    [CreateAssetMenu(menuName = "Items/Create ItemDataSo", fileName = "ItemDataSo", order = 0)]
    public class ItemDataSo : ScriptableObject
    {
        [Header("MetaData")]
        public ItemMetaData itemMetaData;
        [Header("Item")]
        public Sprite itemIcon;
        public string itemDescription;
    }
}