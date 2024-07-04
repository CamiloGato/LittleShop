using UI.Views;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Controllers
{
    public class ShopTransactionController : BaseController<ShopTransactionView>
    {
        [Header("Events")]
        [SerializeField] private UnityEvent transactionButtonEvent;
        [SerializeField] private UnityEvent backButtonEvent;
        
        public override void Initialize()
        {
            base.Initialize();
            baseView.backButtonEvent.AddListener(BackButton);
            baseView.transactionButtonEvent.AddListener(TransactionButton);
        }
        
        public override void Close()
        {
            base.Close();
            baseView.backButtonEvent.RemoveAllListeners();
            baseView.transactionButtonEvent.RemoveAllListeners();
        }
        
        #region Methods
        
        public void SetTransactionText(string text)
        {
            baseView.SetTransactionText(text);
        }
        
        #endregion
        
        #region Events
        
        private void BackButton()
        {
            backButtonEvent.Invoke();
        }

        private void TransactionButton()
        {
            transactionButtonEvent.Invoke();
        }
        
        #endregion
    }
}