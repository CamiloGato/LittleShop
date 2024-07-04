using System;
using UnityEngine;

namespace UI.Models
{
    [Serializable]
    public class ItemModel
    {
        public string name;
        public Sprite icon;
        public int value;
        public string description;
    }
    
    [Serializable]
    public class ClothModel : ItemModel
    {
        public ClothImagePostureModel clothImagePosture;
    }
}