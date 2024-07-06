using UI.Models;

namespace Shop.Inventory
{
    public class EntityInventoryService : IInventoryService
    {
        public InventoryHistory CreateInventoryHistory(PlayerInventoryModelSo from, PlayerInventoryModelSo to)
        {
            return new InventoryHistory()
            {
                from = from,
                to = to
            };
        }

        public InventoryHistory AddItem(InventoryHistory inventoryHistory, ItemModelSo item)
        {
            inventoryHistory.AddItem(item);
            return inventoryHistory;
        }

        public bool ExecuteReplace(InventoryHistory inventoryHistory)
        {
            if (!inventoryHistory.CanExecute()) return false;
            
            inventoryHistory.from.RemoveItem(inventoryHistory.items);
            inventoryHistory.to.AddItem(inventoryHistory.items);
            return true;
        }
    }
}