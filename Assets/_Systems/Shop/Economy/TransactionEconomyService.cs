using Manager;
using UI.Models;

namespace Shop.Economy
{
    public class TransactionEconomyService : IEconomyService
    {
        public BillHistory CreateTransaction(PlayerWalletModelSo from, PlayerWalletModelSo to)
        {
            return new BillHistory()
            {
                to = to,
                from = from,
            };
        }

        public BillHistory AddItem(BillHistory transactionHistory, ItemModelSo item)
        {
            transactionHistory.AddItemPrice(item.value);
            return transactionHistory;
        }

        public bool ExecuteTransaction(BillHistory transactionHistory)
        {
            if (!transactionHistory.CanExecute()) return false;
            
            transactionHistory.to.RemoveMoney(transactionHistory.amount);
            transactionHistory.from.AddMoney(transactionHistory.amount);
            return true;
        }
    }
}