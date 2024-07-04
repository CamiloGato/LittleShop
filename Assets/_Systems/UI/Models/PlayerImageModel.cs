using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    
    [Serializable]
    public enum ClothImageType
    {
        Base,
        Out,
        Har,
        Hat
    }
    
    [Serializable]
    public class ClothImagePostureModel
    {
        public ClothImageType type;
        public Sprite down;
        public Sprite up;
        public Sprite left;
        public Sprite right;

        public Sprite this[int index]
        {
            get
            {
                return index switch
                {
                    0 => down,
                    1 => left,
                    2 => up,
                    3 => right,
                    _ => null
                };
            }
        }
        
        
    }
    
    [Serializable]
    public class PlayerImageModel
    {
        public List<ClothImagePostureModel> clothSprites;
        
        private int _currentLook;
        public int CurrentLook
        {
            get => _currentLook;
            set => _currentLook = value;
        }
        
        public Sprite this[ClothImageType type]
        {
            get
            {
                // Save the cloth
                ClothImagePostureModel cloth = 
                    clothSprites.Find(x => x.type == type);
                // Return the cloth current look sprite
                return cloth?[CurrentLook];
            }
        }

        public void ChangeClothLook(ClothImagePostureModel cloth)
        {
            ClothImagePostureModel currentCloth = clothSprites.Find(x => x.type == cloth.type);
            currentCloth.down = cloth.down;
            currentCloth.up = cloth.up;
            currentCloth.left = cloth.left;
            currentCloth.right = cloth.right;
        }
        
    }
}