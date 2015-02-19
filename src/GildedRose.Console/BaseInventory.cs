using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public abstract class BaseInventory : IInventory
    {
        protected Item _item;

        public BaseInventory(Item item)
        {
            _item = item;
        }

        public abstract void Update();

        public int GetSellIn()
        {
            return _item.SellIn;
        }

        public int GetQuality()
        {
            return _item.Quality;
        }
    }
}
