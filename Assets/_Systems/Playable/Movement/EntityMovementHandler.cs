using UnityEngine;
using UnityEngine.AI;

namespace Playable.Movement
{
    public class EntityMovementHandler : IMovementHandler
    {
        private readonly NavMeshAgent _navMeshAgent;

        public EntityMovementHandler(NavMeshAgent navMeshAgent)
        {
            _navMeshAgent = navMeshAgent;
            
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
        }

        public void Move(Vector2 direction)
        {
            _navMeshAgent.SetDestination(direction);
        }
    }
}