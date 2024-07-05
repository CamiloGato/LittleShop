using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Models
{
    [CreateAssetMenu(menuName = "Player/Create Player Clothes", fileName = "PlayerClothesModelSo", order = 0)]
    public class PlayerClothesModelSo : ScriptableObject
    {
        public UnityEvent<ClothModelSo> onClothesChanged;
        public UnityEvent<ItemModelSo> onItemChanged;
        
        public List<ClothModelSo> clothes;
        public ItemModelSo item;
        
        public ClothModelSo GetCloth(ClothType type)
        {
            return clothes.Find(x => x.type == type);
        }
        
        public void ChangeCloth(ClothModelSo clothModel)
        {
            ClothModelSo modelSo = clothes.Find(x => x.type == clothModel.type);
            modelSo.ChangeLook(clothModel);
            onClothesChanged?.Invoke(modelSo);
        }
        
        public void ChangeItem(ItemModelSo itemModel)
        {
            item = itemModel;
            onItemChanged?.Invoke(itemModel);
        }
        
    }
}