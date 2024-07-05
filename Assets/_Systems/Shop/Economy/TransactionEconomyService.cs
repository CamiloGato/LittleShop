using Manager;
using UI.Models;

namespace Shop.Economy
{
    public class TransactionEconomyService : IEconomyService
    {
        public Transaction CreateTransaction(PlayerWalletModelSo from, PlayerWalletModelSo to, int amount)
        {
            return new Transaction()
            {
                from = from,
                to = to,
                amount = amount
            };
        }

        public bool ExecuteTransaction(Transaction transaction)
        {
            if (!transaction.CanExecute()) return false;
            
            transaction.from.RemoveMoney(transaction.amount);
            transaction.to.AddMoney(transaction.amount);
            transaction.time = TimeManager.Instance.timeStampModel.TimeString;
            return true;
        }
    }
}