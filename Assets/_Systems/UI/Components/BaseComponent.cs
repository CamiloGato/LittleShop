using UnityEngine;

namespace UI.Components
{
    public abstract class BaseComponent : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Close();
    }
}