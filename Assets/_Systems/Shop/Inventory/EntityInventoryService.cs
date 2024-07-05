using UI.Models;

namespace Shop.Inventory
{
    public class EntityInventoryService : IInventoryService
    {
        public bool ReplaceItem(PlayerInventoryModelSo from, PlayerInventoryModelSo to, ItemModelSo item)
        {
            if (from.HasItem(item))
            {
                from.AddItem(item);
                to.RemoveItem(item);
                return true;
            }
            
            return false;
        }
    }
}