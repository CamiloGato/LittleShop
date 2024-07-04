using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    
    [Serializable]
    public class ClothImagePostureModel
    {
        public Sprite down;
        public Sprite up;
        public Sprite left;
        public Sprite right;

        private Dictionary<int, Sprite> _postureSprites = new Dictionary<int, Sprite>();

        public Sprite this[int index]
        {
            get => _postureSprites[index];
            set => _postureSprites[index] = value;
        }
        
    }
    
    [Serializable]
    public class PlayerImageModel
    {
        public ClothImagePostureModel baseSprite;
        public ClothImagePostureModel outSprite;
        public ClothImagePostureModel harSprite;
        public ClothImagePostureModel hatSprite;
        
        private int _currentLook;
        public int CurrentLook
        {
            get => _currentLook;
            set => _currentLook = value;
        }
        
        public Sprite BaseSprite => baseSprite[_currentLook];
        public Sprite OutSprite => outSprite[_currentLook];
        public Sprite HarSprite => harSprite[_currentLook];
        public Sprite HatSprite => hatSprite[_currentLook];
        
    }
}