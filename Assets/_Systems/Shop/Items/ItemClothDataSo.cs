using System.Collections.Generic;
using UI.Models;
using UnityEngine;

namespace Shop.Items
{
    [CreateAssetMenu(menuName = "Items/Create ItemClothDataSo", fileName = "ItemClothDataSo", order = 0)]
    public class ItemClothDataSo : ItemDataSo
    {
        [Header("Cloth")]
        public ClothImageType clothType;
        public List<Sprite> clothDown;
        public List<Sprite> clothUp;
        public List<Sprite> clothLeft;
        public List<Sprite> clothRight;
    }
}