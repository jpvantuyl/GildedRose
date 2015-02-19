using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public static class InventoryService
    {
        public static void Process(IEnumerable<IInventory> inventoryItems)
        {
            foreach (var item in inventoryItems)
            {
                Process(item);
            }
        }

        public static void Process(IInventory item)
        {
            item.Update();
        }
    }
}
