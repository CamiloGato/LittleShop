using UI.Models;

namespace Shop.Economy
{
    public interface IEconomyService
    {
        BillHistory CreateTransaction(PlayerWalletModelSo from, PlayerWalletModelSo to);
        BillHistory AddItem(BillHistory transactionHistory, ItemModelSo item);
        bool ExecuteTransaction(BillHistory transactionHistory);
    }
}