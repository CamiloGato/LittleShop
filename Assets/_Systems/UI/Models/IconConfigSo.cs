using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    public class IconConfigSo : ScriptableObject
    {
        [SerializeField] private List<IconModelSo> icons;
        
        public Sprite GetIcon(string iconName)
        {
            foreach (IconModelSo icon in icons)
            {
                if (icon.iconName == iconName)
                {
                    return icon.icon;
                }
            }
            return null;
        }
    }
}