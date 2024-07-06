using UnityEngine;
using UnityEngine.InputSystem;

namespace Playable.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActions;
        [SerializeField] private float moveSpeed = 5f;

        private Rigidbody2D _rb;
        private InputAction _moveAction;
        private Vector2 _moveInput;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            
            InputActionMap actionMap = inputActions.FindActionMap("Player");
            _moveAction = actionMap.FindAction("Move");

            _moveAction.Enable();
        }

        private void OnEnable()
        {
            _moveAction.performed += OnMovePerformed;
            _moveAction.canceled += OnMoveCanceled;
        }

        private void OnDisable()
        {
            _moveAction.performed -= OnMovePerformed;
            _moveAction.canceled -= OnMoveCanceled;

            _moveAction.Disable();
        }

        private void FixedUpdate()
        {
            if (PlayerInteraction.CanInteract)
            {
                _rb.velocity = _moveInput * moveSpeed;
            }
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
            _moveInput.Normalize();
        }

        private void OnMoveCanceled(InputAction.CallbackContext context)
        {
            _moveInput = Vector2.zero;
        }
    }
}