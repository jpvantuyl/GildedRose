using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class BoringInventory : BaseInventory
    {
        public BoringInventory(Item item)
            : base(item)
        {
        }

        public override void Update()
        {
            _item.DecreaseQuality();

            _item.DecreaseSellIn();

            if (_item.SellIn < 0)
                _item.DecreaseQuality();
        }
    }
}
