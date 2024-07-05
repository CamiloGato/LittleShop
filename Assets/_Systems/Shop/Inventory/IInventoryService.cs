using UI.Models;

namespace Shop.Inventory
{
    public interface IInventoryService
    {
        bool ReplaceItem(PlayerInventoryModelSo from, PlayerInventoryModelSo to, ItemModelSo item);
    }
}