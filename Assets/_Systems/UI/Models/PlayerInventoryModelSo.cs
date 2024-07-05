using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(menuName = "Player/Create Player Inventory", fileName = "PlayerInventoryModelSo", order = 0)]
    public class PlayerInventoryModelSo : ScriptableObject
    {
        [SerializeField] private List<ItemModelSo> items;
    }
}