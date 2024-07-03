using UnityEngine;

namespace Playable.Movement
{
    public interface IMovementHandler
    {
        void Move(Vector2 direction);
    }
}