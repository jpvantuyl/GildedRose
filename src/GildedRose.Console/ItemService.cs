using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public static class ItemService
    {
        public static void Update(IList<Item> Items)
        {
            foreach (var item in Items)
            {
                Update(item);
            }
        }

        public static void Update(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros")
            {
                DecreaseQuality(item);
            }
            else
            {
                IncreaseQuality(item);

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        IncreaseQuality(item);
                    }

                    if (item.SellIn < 6)
                    {
                        IncreaseQuality(item);
                    }
                }
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                DecreaseSellIn(item);
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        DecreaseQuality(item);
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    IncreaseQuality(item);
                }
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
                item.Quality = item.Quality - 1;
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < Constants.MAX_QUALITY)
                item.Quality = item.Quality + 1;
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}
