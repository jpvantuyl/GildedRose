using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public static class InventoryFactory
    {
        public static IInventory Create(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new LegendaryInventory(item);
            if (item.Name == "Aged Brie")
                return new AppreciatingInventory(item);
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                return new BackstagePassInventory(item);
            return new BoringInventory(item);
        }
    }
}
