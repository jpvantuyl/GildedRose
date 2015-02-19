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
            _item.IncreaseQuality();

            _item.DecreaseSellIn();

            if (_item.SellIn < 0)
                _item.IncreaseQuality();
        }
    }
}
