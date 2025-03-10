﻿using Playable.Interact;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Playable.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        public static bool CanInteract = true;
        
        public InputActionAsset inputActions;
        
        private Camera _mainCamera;
        private InputAction _clickAction;
        private InputAction _hoverAction;
        private IInteractable _currentInteractable;
        private Player _player;
        
        private void Awake()
        {
            _mainCamera = Camera.main;

            _player = GetComponent<Player>();
            var actionMap = inputActions.FindActionMap("Player", true);
            _clickAction = actionMap.FindAction("Click", true);
            _hoverAction = actionMap.FindAction("Point", true);

            _clickAction.Enable();
            _hoverAction.Enable();
        }

        private void OnEnable()
        {
            _clickAction.performed += OnClickPerformed;
        }

        private void OnDisable()
        {
            _clickAction.performed -= OnClickPerformed;
        }

        private void Update()
        {
            if (CanInteract)
            {
                HandleHover();
            }
        }

        private void OnClickPerformed(InputAction.CallbackContext context)
        {
            if (!CanInteract)
            {
                return;
            }
            
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.OnClick(_player);
                }
            }
        }

        private void HandleHover()
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    if (_currentInteractable != interactable)
                    {
                        if (_currentInteractable != null)
                        {
                            _currentInteractable.OnHoverExit();
                        }

                        _currentInteractable = interactable;
                        _currentInteractable.OnHoverEnter();
                    }
                }
            }
            else if (_currentInteractable != null)
            {
                _currentInteractable.OnHoverExit();
                _currentInteractable = null;
            }
        }
    }
}
