using UnityEngine;
using UnityEngine.InputSystem;

namespace Playable.Input
{
    public class PointClickInputHandler : IInputHandler
    {
        private readonly Camera _camera;
        private Vector2 _clickPosition;
        private bool _clickTriggered;

        public PointClickInputHandler(InputActionAsset inputActionAsset, Camera camera)
        {
            _camera = camera;
            
            InputActionMap actionMap = inputActionAsset.FindActionMap("Player", true);
            InputAction clickAction = actionMap.FindAction("Click", true);

            clickAction.performed += OnClick;
            clickAction.canceled += OnClickReleased;

            clickAction.Enable();
        }
        public Vector2 GetPosition()
        {
            return _clickPosition;
        }

        public bool IsPressed()
        {
            return _clickTriggered;
        }
        
        #region InputAction Callbacks
        
        private void OnClick(InputAction.CallbackContext context)
        {
            _clickTriggered = true;

            Vector2 screenPoint = Mouse.current.position.ReadValue();
            Vector2 worldPoint = _camera.ScreenToWorldPoint(screenPoint);

            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider)
            {
                _clickPosition = hit.point;
            }
        }

        private void OnClickReleased(InputAction.CallbackContext obj)
        {
            _clickTriggered = false;
        }
        
        #endregion
        
    }
}