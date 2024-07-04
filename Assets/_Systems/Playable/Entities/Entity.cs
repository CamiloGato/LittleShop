using Playable.Input;
using Playable.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Playable.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Entity : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private InputActionAsset inputActionAsset;
        [SerializeField] private float speed = 5f;

        private Rigidbody2D _rigidbody2D;
        private IInputHandler _inputHandler;
        private IMovementHandler _movementHandler;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _inputHandler = new PointClickInputHandler(inputActionAsset, mainCamera);
            _movementHandler = new EntityMovementHandler(_rigidbody2D, speed);
        }

        private void Update()
        {
            if (_inputHandler.IsPressed())
            {
                Vector2 position = _inputHandler.GetPosition();
                _movementHandler.Move(position);
            }
        }
    }
}