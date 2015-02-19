using System;
namespace GildedRose.Console
{
    public interface IInventory
    {
        void Update();

        int GetSellIn();

        int GetQuality();
    }
}
