﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Models
{
    [Serializable]
    public class PlayerClothesList
    {
        public ClothModelSo baseCloth;
        public ClothModelSo outCloth;
        public ClothModelSo harCloth;
        public ClothModelSo hatCloth;

        public PlayerClothesList(PlayerClothesList playerClothesList)
        {
            baseCloth = playerClothesList.baseCloth;
            outCloth = playerClothesList.outCloth;
            harCloth = playerClothesList.harCloth;
            hatCloth = playerClothesList.hatCloth;
        }

        public bool HasCloth(ClothModelSo clothModel)
        {
            // TODO: Refactor, smell bad
            return baseCloth == clothModel || outCloth == clothModel || harCloth == clothModel || hatCloth == clothModel;
        }
        
        public void ChangeLook(ClothModelSo clothModel)
        {
            switch (clothModel.type)
            {
                case ClothType.Base:
                    baseCloth = clothModel;
                    break;
                case ClothType.Out:
                    outCloth = clothModel;
                    break;
                case ClothType.Har:
                    harCloth = clothModel;
                    break;
                case ClothType.Hat:
                    hatCloth = clothModel;
                    break;
            }
        }
        
        public ClothModelSo this[ClothType type]
        {
            get
            {
                return type switch
                {
                    ClothType.Base => baseCloth,
                    ClothType.Out => outCloth,
                    ClothType.Har => harCloth,
                    ClothType.Hat => hatCloth,
                    _ => null
                };
            }
        }
    }
    
    [CreateAssetMenu(menuName = "Player/Create Player Clothes", fileName = "PlayerClothesModelSo", order = 0)]
    public class PlayerClothesModelSo : ScriptableObject
    {
        public UnityEvent<ClothModelSo> onClothesChanged;
        public UnityEvent<ItemModelSo> onItemChanged;
        
        public PlayerClothesList clothes;
        public ItemModelSo item;

        public bool HasItem(ItemModelSo itemModelSo)
        {
            if (item is ClothModelSo clothModelSo)
            {
                return clothes.HasCloth(clothModelSo);
            }
            return item == itemModelSo;
        }
        
        public ClothModelSo GetCloth(ClothType type)
        {
            return clothes[type];
        }
        
        public void ChangeCloth(ClothModelSo clothModel)
        {
            ClothModelSo modelSo = clothes[clothModel.type];
            clothes.ChangeLook(clothModel);
            onClothesChanged?.Invoke(modelSo);
        }
        
        public void ChangeCloth(PlayerClothesList playerClothesList)
        {
            clothes = new PlayerClothesList(playerClothesList);
            // TODO: I could use another way
            onClothesChanged?.Invoke(clothes.baseCloth);
            onClothesChanged?.Invoke(clothes.outCloth);
            onClothesChanged?.Invoke(clothes.harCloth);
            onClothesChanged?.Invoke(clothes.hatCloth);
        }
        
        public void ChangeItem(ItemModelSo itemModel)
        {
            item = itemModel;
            onItemChanged?.Invoke(itemModel);
        }
        
    }
}