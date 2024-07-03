using UnityEngine;
using UnityEngine.InputSystem;

namespace Playable.Input
{
    public class KeyboardInputHandler : IInputHandler
    {
        private readonly Transform _entityTransform;
        private Vector2 _moveInput;
        private bool _actionButtonPressed;
        
        public KeyboardInputHandler(InputActionAsset inputActionAsset, Transform entityTransform)
        {
            _entityTransform = entityTransform;
            
            InputActionMap actionMap = inputActionAsset.FindActionMap("Player", true);
            InputAction moveAction = actionMap.FindAction("Move", true);
            InputAction actionButtonAction = actionMap.FindAction("Action", true);

            moveAction.performed += OnMoveActionOnperformed;
            moveAction.canceled += OnMoveActionOncanceled;
            
            actionButtonAction.performed += OnActionButtonActionOnperformed;
            actionButtonAction.canceled += OnActionButtonActionOncanceled;

            moveAction.Enable();
            actionButtonAction.Enable();
        }
        
        public Vector2 GetPosition()
        {
            return _moveInput;
        }

        public bool IsPressed()
        {
            return _actionButtonPressed;
        }
        
        #region InputAction Callbacks
        
        private void OnActionButtonActionOncanceled(InputAction.CallbackContext ctx)
        {
            _actionButtonPressed = false;
        }

        private void OnActionButtonActionOnperformed(InputAction.CallbackContext ctx)
        {
            _actionButtonPressed = ctx.ReadValueAsButton();
        }

        private void OnMoveActionOncanceled(InputAction.CallbackContext ctx)
        {
            _moveInput = _entityTransform.position;
        }

        private void OnMoveActionOnperformed(InputAction.CallbackContext ctx)
        {
            Vector3 value = ctx.ReadValue<Vector2>();
            _moveInput = _entityTransform.position + value;
        }

        #endregion

        
    }
}