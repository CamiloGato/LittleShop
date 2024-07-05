using UnityEngine;

namespace UI.Models
{
    
    [CreateAssetMenu(menuName = "Icon/Create Icon", fileName = "IconModelSo", order = 0)]
    public class IconModelSo : ScriptableObject
    {
        public string iconName;
        public Sprite icon;
    }
}