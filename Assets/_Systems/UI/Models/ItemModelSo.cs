using UnityEngine;

namespace UI.Models
{
    
    [CreateAssetMenu(menuName = "Item/Create Item", fileName = "ItemModelSo", order = 0)]
    public class ItemModelSo : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        public int value;
        public string description;
    }
}