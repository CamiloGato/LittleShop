using System.Collections.Generic;
using UnityEngine;

namespace UI.Icon
{
    public class IconDataBaseSo : ScriptableObject
    {
        public List<IconData> icons;

        public Sprite GetIcon(string iconName)
        {
            return icons.Find(x => x.name == iconName).icon;
        }
    }
}