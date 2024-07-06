using UnityEngine;

namespace UI.Views
{
    public abstract class BaseView : MonoBehaviour
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup canvasGroup;
        
        public virtual void Initialize()
        {
            canvasGroup.alpha = 1;
        }

        public virtual void Close()
        {
            canvasGroup.alpha = 0;
        }
    }
}