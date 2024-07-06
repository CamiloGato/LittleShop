using UI.Models;

namespace Shop.Inventory
{
    public interface IInventoryService
    {
        InventoryHistory CreateInventoryHistory(PlayerInventoryModelSo from, PlayerInventoryModelSo to);
        InventoryHistory AddItem(InventoryHistory inventoryHistory, ItemModelSo item);
        bool ExecuteReplace(InventoryHistory inventoryHistory);
    }
}