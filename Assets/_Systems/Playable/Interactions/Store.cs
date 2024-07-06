using System.Collections.Generic;
using Shop.Trade;
using UI.Models;

namespace Playable.Interactions
{
    public class Store : TradeEntity
    {
        public void FillItemsToBuy(List<ItemModelSo> itemsToBuy)
        {
            Inventory.AddItem(itemsToBuy);
        }
        
    }
}