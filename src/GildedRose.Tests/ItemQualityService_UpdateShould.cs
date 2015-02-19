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
        public void LowerSellInBelowZero()
        {
            var item = GetBoringItem(sellIn: 0);

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(-1, item.SellIn);
        }

        [TestMethod]
        public void NotLowerQualityBelowZero()
        {
            var item = GetBoringItem(quality: 0);

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(0, item.Quality);
        }

        [TestMethod]
        public void IncreaseQualityByOneForAgedBrie()
        {
            var item = GetAgedBrie();
            var originalQuality = item.Quality;

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(originalQuality + 1, item.Quality);
        }

        [TestMethod]
        public void IncreaseQualityByTwoForAgedBrieWhenExpired()
        {
            var item = GetAgedBrie(sellIn: 0);
            var originalQuality = item.Quality;

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(originalQuality + 2, item.Quality);
        }

        [TestMethod]
        public void NotIncreaseQualityAboveMax()
        {
            var item = GetAgedBrie(quality: Constants.MAX_QUALITY);

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(Constants.MAX_QUALITY, item.Quality);
        }

        [TestMethod]
        public void NotChangeQualityForLegendaryItem()
        {
            var item = GetLegendaryItem();
            var originalQuality = item.Quality;

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(originalQuality, item.Quality);
        }

        [TestMethod]
        public void NotChangeSellInForLegendaryItem()
        {
            var item = GetLegendaryItem();
            var originalSellIn = item.SellIn;

            ItemQualityService.UpdateItemQuality(item);

            Assert.AreEqual(originalSellIn, item.SellIn);
        }


        private Item GetBoringItem(int sellIn = 10, int quality = 20)
        {
            return new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };
        }

        private Item GetAgedBrie(int sellIn = 10, int quality = 20)
        {
            return new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
        }

        private Item GetLegendaryItem()
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        }
    }
}