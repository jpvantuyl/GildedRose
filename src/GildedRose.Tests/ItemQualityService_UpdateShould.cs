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

        [TestMethod]
        public void LowerQualityByOne()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(19, item.Quality);
        }

        [TestMethod]
        public void LowerQualityByTwoWhenSellInIsZero()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 };

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(18, item.Quality);
        }

        [TestMethod]
        public void NotLowerQualityBelowZero()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 };

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(0, item.Quality);
        }
    }
}