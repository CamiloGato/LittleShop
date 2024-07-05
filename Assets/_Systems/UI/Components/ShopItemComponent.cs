using TMPro;
using UI.Models;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Components
{
    public class ItemComponent : BaseComponent
    {
        [Header("Item")]
        [SerializeField] private Button button;
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text itemValue;
        [SerializeField] private TMP_Text itemDescription;
        [SerializeField] private Image selectedImage;
        
        private ItemModelSo _itemModel;
        public ItemModelSo ItemModel => _itemModel;
        
        private UnityAction<ItemComponent> _callback;
        
        public override void Initialize()
        {
            button.onClick.AddListener(OnClick);
            
            SetSelected(false);
        }
        
        public override void Close()
        {
            icon.sprite = null;
            itemName.text = "";
            itemValue.text = "";
            itemDescription.text = "";
            _itemModel = null;
            _callback = null;
            
            button.onClick.RemoveAllListeners();
        }

        public void SetItem(ItemModelSo itemModel)
        {
            _itemModel = itemModel;
            
            icon.sprite = _itemModel.icon;
            itemName.text = _itemModel.itemName;
            itemValue.text = _itemModel.value.ToString();
            itemDescription.text = _itemModel.description;
        }
        
        public void SetSelected(bool selected)
        {
            selectedImage.gameObject.SetActive(selected);
        }
        
        public void ButtonStatus(bool active)
        {
            button.interactable = active;
        }
        
        private void OnClick()
        {
            _callback?.Invoke(this);
        }
        
        public void AddCallback(UnityAction<ItemComponent> callback)
        {
            _callback = callback;
        }
    }
}