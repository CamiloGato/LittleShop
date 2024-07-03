using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public abstract class BaseController<T> : MonoBehaviour where T : BaseView
    {
        [SerializeField] protected T baseView;
        
        public virtual void Initialize()
        {
            baseView.Initialize();
        }
           
        public virtual void Close()
        {
            baseView.Close();
        }
           
    }
}