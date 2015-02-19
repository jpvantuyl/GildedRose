using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class BackstagePassInventory : BaseInventory
    {
        public BackstagePassInventory(Item item)
            : base(item)
        {
        }

        public override void Update()
        {
            _item.IncreaseQuality();

            if (_item.SellIn < 11)
                _item.IncreaseQuality();

            if (_item.SellIn < 6)
                _item.IncreaseQuality();

            _item.DecreaseSellIn();

            if (_item.SellIn < 0)
                _item.Quality = 0;
        }
    }
}
