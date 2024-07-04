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
        
        private ComponentPool<PopUpComponent> _popUpPool;
        
        public override void Initialize()
        {
            base.Initialize();
            _popUpPool = new ComponentPool<PopUpComponent>(popUpComponentPrefab, sectionGroup, 3);
            destroyPopUpEvent = new UnityEvent<PopUpComponent>();
            destroyPopUpEvent.AddListener(RemovePopUp);
        }
        
        public override void Close()
        {
            base.Close();
            _popUpPool.Clear();
        }
        
        #region Methods
        public void AddPopUp(PopUpModel popUpData)
        {
            PopUpComponent popUp = _popUpPool.Get();
            popUp.Initialize();
            popUp.SetCallback(destroyPopUpEvent);
            popUp.SetPopUp(popUpData);
        }

        public void RemovePopUp(PopUpComponent popUp)
        {
            popUp.Close();
            _popUpPool.ReturnToPool(popUp);
        }
        #endregion
    }
}