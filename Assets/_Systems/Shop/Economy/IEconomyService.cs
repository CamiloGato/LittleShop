using UI.Models;

namespace Shop.Economy
{
    public interface IEconomyService
    {
        Transaction CreateTransaction(PlayerWalletModelSo from, PlayerWalletModelSo to, int amount);
        bool ExecuteTransaction(Transaction transaction);
    }
}