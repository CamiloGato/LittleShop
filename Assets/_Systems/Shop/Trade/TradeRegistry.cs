using System;
using System.Collections.Generic;
using Shop.Items;

namespace Shop.Trade
{
    [Serializable]
    public class TradeRegistry
    {
        public string tradeId;
        public TradeEntityMetaData tradeEntityFrom;
        public TradeEntityMetaData tradeEntityTo;
        public List<ItemMetaData> items;
        public int totalAmount;
    }
}