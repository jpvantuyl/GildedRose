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
            var item = GetBoringItem();
            var originalSellIn = item.SellIn;

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(originalSellIn - 1, item.SellIn);
        }

        [TestMethod]
        public void LowerQualityByOne()
        {
            var item = GetBoringItem();
            var originalQuality = item.Quality;

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(originalQuality - 1, item.Quality);
        }

        [TestMethod]
        public void LowerQualityByTwoWhenSellInIsZero()
        {
            var item = GetBoringItem(sellIn: 0);
            var originalQuality = item.Quality;

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(originalQuality - 2, item.Quality);
        }

        [TestMethod]
        public void NotLowerQualityBelowZero()
        {
            var item = GetBoringItem(quality: 0);

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(0, item.Quality);
        }

        private Item GetBoringItem(int sellIn = 10, int quality = 20)
        {
            return new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };
        }
    }
}