using UnityEngine;

namespace UI.Views
{
    public abstract class BaseView : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Close();
    }
}