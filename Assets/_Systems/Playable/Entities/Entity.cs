using Playable.Input;
using Playable.Movement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Playable.Entities
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Entity : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActionAsset;
        
        private NavMeshAgent _navMeshAgent;
        
        private IInputHandler _inputHandler;
        private IMovementHandler _movementHandler;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _inputHandler = new KeyboardInputHandler(inputActionAsset, transform);
            _movementHandler = new EntityMovementHandler(_navMeshAgent);
        }

        private void Update()
        {
            Vector2 position = _inputHandler.GetPosition();
            Debug.Log(position);
            _movementHandler.Move(position);
        }
    }
}