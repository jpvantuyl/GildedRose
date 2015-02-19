﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    class ConjuredInventory : BaseInventory
    {
        public ConjuredInventory(Item item)
            : base(item)
        {
        }

        public override void Update()
        {
            _item.DecreaseQuality();
            _item.DecreaseQuality();

            _item.DecreaseSellIn();

            if (_item.SellIn < 0)
            {
                _item.DecreaseQuality();
                _item.DecreaseQuality();
            }
        }
    }
}