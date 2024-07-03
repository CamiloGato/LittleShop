using Items.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class ShopItemComponent : BaseComponent
    {
        [Header("Item")]
        [SerializeField] private GameObject background;
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text itemValue;
        [SerializeField] private TMP_Text itemDescription;
        
        private ItemDataSO _itemDataSo;
        
        public override void Initialize()
        {
            if (!_itemDataSo) throw new System.Exception("ItemDataSO has not been assigned");
            
            icon.sprite = _itemDataSo.icon;
            itemName.text = _itemDataSo.item.name;
            itemValue.text = _itemDataSo.item.value.ToString();
            itemDescription.text = _itemDataSo.item.description;
        }

        public override void Close()
        {
        }

        public void SetItem(ItemDataSO itemDataSo)
        {
            _itemDataSo = itemDataSo;
        }
    }
}