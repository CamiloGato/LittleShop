using UI.Components;
using UI.Components.Pool;
using UnityEngine;
using UI.Views;
using UI.Models;
using UnityEngine.Events;

namespace UI.Controllers
{
    public class PopUpController : BaseController<PopUpView>
    {
        [Header("Components Prefab")]
        [SerializeField] private PopUpComponent popUpComponentPrefab;

        [Header("Section Group")]
        [SerializeField] private RectTransform sectionGroup;

        [Header("Events")]
        [SerializeField] private UnityEvent<PopUpComponent> destroyPopUpEvent;

        private ComponentPool<PopUpComponent> _popUpPool;

        public override void Initialize()
        {
            base.Initialize();
            InitializeComponents();
            InitializeEvents();
        }

        public override void Close()
        {
            base.Close();
            _popUpPool.Clear();
        }

        private void InitializeComponents()
        {
            _popUpPool = new ComponentPool<PopUpComponent>(popUpComponentPrefab, sectionGroup, 3);
        }

        private void InitializeEvents()
        {
            destroyPopUpEvent = new UnityEvent<PopUpComponent>();
            destroyPopUpEvent.AddListener(RemovePopUp);
        }

        public void AddPopUp(PopUpModel popUpData)
        {
            var popUp = _popUpPool.Get();
            popUp.Initialize();
            popUp.SetCallback(destroyPopUpEvent);
            popUp.SetPopUp(popUpData);
        }

        private void RemovePopUp(PopUpComponent popUp)
        {
            popUp.Close();
            _popUpPool.ReturnToPool(popUp);
        }
    }
}