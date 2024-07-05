using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(menuName = "Item/Create Item Cloth", fileName = "ItemModelSo", order = 0)]
    public class ItemClothModelSo : ItemModelSo
    {
        public ClothModelSo clothModel;
    }
}