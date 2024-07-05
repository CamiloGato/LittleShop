using System;
using System.Collections.Generic;
using Shop.Items;
using UI.Models;

namespace Shop.Mappers
{
    public static class ItemsMappers
    {
        public static List<ItemModel> MapToItemModel(this List<ItemDataSo> items)
        {
            List<ItemModel> itemModels = new List<ItemModel>();
            foreach (ItemDataSo item in items)
            {
                itemModels.Add(item.ToItemModel());
            }
            return itemModels;
        }
        
        public static ItemModel ToItemModel(this ItemDataSo itemMetaData)
        {
            return new ItemModel()
            {
                name = itemMetaData.itemMetaData.name,
                icon = itemMetaData.itemIcon,
                value = itemMetaData.itemMetaData.value,
                description = itemMetaData.itemDescription
            };
        }

        public static ItemMetaData MetaDataFrom(this ItemModel item, List<ItemDataSo> itemDataSo)
        {
            foreach (ItemDataSo data in itemDataSo)
            {
                if (data.itemMetaData.name.Equals(item.name))
                {
                    return data.itemMetaData;
                }
            }
            throw new Exception("Item not found");
        }
        
        public static List<ItemMetaData> MetaDataFrom(this List<ItemModel> items, List<ItemDataSo> itemDataSos)
        {
            List<ItemMetaData> itemMetaDatas = new List<ItemMetaData>();

            foreach (ItemModel item in items)
            {
                ItemMetaData metaData = item.MetaDataFrom(itemDataSos);
                itemMetaDatas.Add(metaData);
            }
            
            return itemMetaDatas;
        }
    }
}