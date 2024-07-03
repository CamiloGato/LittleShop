using UnityEngine;

namespace Items.Models
{
    [CreateAssetMenu(menuName = "Items/ItemDataSO", fileName = "ItemDataSO", order = 0)]
    public class ItemDataSO : ScriptableObject
    {
        public Item item;
        public Sprite icon;
    }
}