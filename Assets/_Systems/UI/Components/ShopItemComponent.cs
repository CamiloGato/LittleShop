using TMPro;
using UI.Models;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Components
{
    public class ShopItemComponent : BaseComponent
    {
        [Header("Item")]
        [SerializeField] private Button button;
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text itemValue;
        [SerializeField] private TMP_Text itemDescription;
        
        private ItemModel _itemModel;
        
        public override void Initialize()
        {
            if (_itemModel == null) throw new System.Exception("ItemDataSO has not been assigned");
            
            icon.sprite = _itemModel.icon;
            itemName.text = _itemModel.name;
            itemValue.text = _itemModel.value.ToString();
            itemDescription.text = _itemModel.description;
        }
        
        public override void Close()
        {
            icon.sprite = null;
            itemName.text = "";
            itemValue.text = "";
            itemDescription.text = "";
            _itemModel = null;
            
            button.onClick.RemoveAllListeners();
        }

        public void SetItem(ItemModel itemModel)
        {
            _itemModel = itemModel;
        }

        public void ListenClick(UnityAction callback)
        {
            button.onClick.AddListener(callback);
        }
    }
}