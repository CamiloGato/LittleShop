using TMPro;
using UI.Models;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Components
{
    public class PopUpComponent : BaseComponent
    {
        [Header("Pop Up")]
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text title;
        [SerializeField] private TMP_Text description;
        
        private UnityEvent<PopUpComponent> _callback;
        
        public override void Initialize()
        {
            
        }

        public override void Close()
        {
            icon.sprite = null;
            title.text = "";
            description.text = "";
            
            _callback = null;
        }
        
        #region Methods
        public void SetCallback(UnityEvent<PopUpComponent> callback)
        {
            _callback = callback;
        }
        
        public void SetPopUp(PopUpModel popUpData)
        {
            icon.sprite = popUpData.icon;
            title.text = popUpData.title;
            description.text = popUpData.description;
        }
        #endregion
        
        #region Animation Events
        public void TurnOff()
        {
            _callback?.Invoke(this);
        }
        #endregion
    }
}