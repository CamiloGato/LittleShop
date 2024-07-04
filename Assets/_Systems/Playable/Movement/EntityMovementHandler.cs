using UnityEngine;

namespace Playable.Movement
{
    public class EntityMovementHandler : IMovementHandler
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly float _speed;

        public EntityMovementHandler(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbody2D = rigidbody2D;
            _speed = speed;
        }

        public void Move(Vector2 position)
        {
            Vector2 direction = (position - _rigidbody2D.position).normalized;
            _rigidbody2D.MovePosition(_rigidbody2D.position + direction * (_speed * Time.deltaTime));
        }
    }
}