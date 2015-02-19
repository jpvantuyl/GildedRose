using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

    public static class ItemExtensions
    {
        public static void DecreaseQuality(this Item item)
        {
            if (item.Quality > 0)
                item.Quality = item.Quality - 1;
        }

        public static void IncreaseQuality(this Item item)
        {
            if (item.Quality < Constants.MAX_QUALITY)
                item.Quality = item.Quality + 1;
        }

        public static void DecreaseSellIn(this Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}
