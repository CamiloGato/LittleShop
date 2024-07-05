using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(menuName = "Icon/Create Icon Config", fileName = "IconConfigSo", order = 0)]
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