using UI.Views;

namespace UI.Controllers
{
    public class ShopTransactionController : BaseController<ShopTransactionView>
    {
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
        
        public void SetTransactionText(string text)
        {
            baseView.SetTransactionText(text);
        }

        private void BackButton()
        {
            
        }

        private void TransactionButton()
        {
            
        }
    }
}