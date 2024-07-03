using UnityEngine;
using UnityEngine.AI;

namespace Playable.Movement
{
    public class EntityMovementHandler : IMovementHandler
    {
        private readonly Transform _entityTransform;
        private readonly NavMeshAgent _navMeshAgent;

        public EntityMovementHandler(Transform entityTransform, NavMeshAgent navMeshAgent)
        {
            _entityTransform = entityTransform;
            _navMeshAgent = navMeshAgent;
        }

        public void Move(Vector2 direction)
        {
            Vector3 newPosition = _entityTransform.position + new Vector3(direction.x, direction.y, 0);
            _navMeshAgent.SetDestination(newPosition);
        }
    }
}