using UI.Components;
using UI.Components.Pool;
using UI.Models;
using UI.Views;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Controllers
{
    public class PopUpController : BaseController<PopUpView>
    {
        [Header("Components Prefab")]
        [SerializeField] private PopUpComponent popUpComponentPrefab;
        
        [Header("Section Group")]
        [SerializeField] private RectTransform sectionGroup;
        
        [Header("Events")][Space]
        [SerializeField] private UnityEvent<PopUpComponent> destroyPopUpEvent;
        
        private ComponentPool<PopUpComponent> _itemPool;
        
        public override void Initialize()
        {
            base.Initialize();
            _itemPool = new ComponentPool<PopUpComponent>(popUpComponentPrefab, sectionGroup);
            destroyPopUpEvent = new UnityEvent<PopUpComponent>();
            destroyPopUpEvent.AddListener(RemovePopUp);
        }
        
        public override void Close()
        {
            base.Close();
            _itemPool.Clear();
        }
        
        #region Methods
        public void AddPopUp(PopUpModel popUpData)
        {
            PopUpComponent popUp = _itemPool.Get();
            popUp.Initialize();
            popUp.SetCallback(destroyPopUpEvent);
            popUp.SetPopUp(popUpData);
        }

        public void RemovePopUp(PopUpComponent popUp)
        {
            popUp.Close();
            _itemPool.ReturnToPool(popUp);
        }
        #endregion
    }
}