using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class AppreciatingInventory : BaseInventory
    {
        public AppreciatingInventory(Item item)
            : base(item)
        {
        }

        public override void Update()
        {
            if (_item.Name != "Aged Brie" && _item.Name != "Backstage passes to a TAFKAL80ETC concert" && _item.Name != "Sulfuras, Hand of Ragnaros")
            {
                _item.DecreaseQuality();
            }
            else
            {
                _item.IncreaseQuality();

                if (_item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (_item.SellIn < 11)
                    {
                        _item.IncreaseQuality();
                    }

                    if (_item.SellIn < 6)
                    {
                        _item.IncreaseQuality();
                    }
                }
            }

            if (_item.Name != "Sulfuras, Hand of Ragnaros")
            {
                _item.DecreaseSellIn();
            }

            if (_item.SellIn < 0)
            {
                if (_item.Name != "Aged Brie")
                {
                    if (_item.Name != "Backstage passes to a TAFKAL80ETC concert" && _item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        _item.DecreaseQuality();
                    }
                    else
                    {
                        _item.Quality = 0;
                    }
                }
                else
                {
                    _item.IncreaseQuality();
                }
            }
        }
    }
}
