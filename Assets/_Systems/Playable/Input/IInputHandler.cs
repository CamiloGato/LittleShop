using UnityEngine;

namespace Playable.Input
{
    public interface IInputHandler
    {
        Vector2 GetPosition();
        bool IsPressed();
    }
}