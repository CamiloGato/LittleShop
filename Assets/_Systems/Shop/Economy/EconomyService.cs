using UI.Models;

namespace Shop.Economy
{
    public class EconomyService
    {
        public bool CreateTransaction(PlayerWalletModelSo from, PlayerWalletModelSo to, int amount)
        {
            if (from.HasEnoughMoney(amount))
            {
                from.RemoveMoney(amount);
                to.AddMoney(amount);
                return true;
            }
            
            return false;
        }
    }
}