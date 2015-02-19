using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ItemQualityService_UpdateShould
    {
        [TestMethod]
        public void LowerSellInByOne()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(9, item.SellIn);
        }
    }
}