using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ItemService_UpdateShould
    {
        [TestMethod]
        public void LowerSellInByOne()
        {
            var item = GetBoringItem();
            var originalSellIn = item.SellIn;

            ItemService.Update(item);

            Assert.AreEqual(originalSellIn - 1, item.SellIn);
        }

        [TestMethod]
        public void LowerQualityByOne()
        {
            var item = GetBoringItem();
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(originalQuality - 1, item.Quality);
        }

        [TestMethod]
        public void LowerQualityByTwoWhenSellInIsZero()
        {
            var item = GetBoringItem(sellIn: 0);
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(originalQuality - 2, item.Quality);
        }

        [TestMethod]
        public void LowerSellInBelowZero()
        {
            var item = GetBoringItem(sellIn: 0);

            ItemService.Update(item);

            Assert.AreEqual(-1, item.SellIn);
        }

        [TestMethod]
        public void NotLowerQualityBelowZero()
        {
            var item = GetBoringItem(quality: 0);

            ItemService.Update(item);

            Assert.AreEqual(0, item.Quality);
        }

        [TestMethod]
        public void IncreaseQualityByOneForAgedBrie()
        {
            var item = GetAgedBrie();
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(originalQuality + 1, item.Quality);
        }

        [TestMethod]
        public void IncreaseQualityByTwoForAgedBrieWhenExpired()
        {
            var item = GetAgedBrie(sellIn: 0);
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(originalQuality + 2, item.Quality);
        }

        [TestMethod]
        public void NotIncreaseQualityAboveMax()
        {
            var item = GetAgedBrie(quality: Constants.MAX_QUALITY);

            ItemService.Update(item);

            Assert.AreEqual(Constants.MAX_QUALITY, item.Quality);
        }

        [TestMethod]
        public void NotChangeQualityForLegendaryItem()
        {
            var item = GetLegendaryItem();
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(originalQuality, item.Quality);
        }

        [TestMethod]
        public void NotChangeSellInForLegendaryItem()
        {
            var item = GetLegendaryItem();
            var originalSellIn = item.SellIn;

            ItemService.Update(item);

            Assert.AreEqual(originalSellIn, item.SellIn);
        }

        [TestMethod]
        public void IncreaseQualityByOneForBackstagePassesAt11Days()
        {
            var item = GetBackstagePasses(sellIn: 11);
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(originalQuality + 1, item.Quality);
        }

        [TestMethod]
        public void IncreaseQualityByTwoForBackstagePassesAt10Days()
        {
            var item = GetBackstagePasses(sellIn: 10);
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(originalQuality + 2, item.Quality);
        }

        [TestMethod]
        public void IncreaseQualityByTwoForBackstagePassesAt6Days()
        {
            var item = GetBackstagePasses(sellIn: 6);
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(originalQuality + 2, item.Quality);
        }

        [TestMethod]
        public void IncreaseQualityByThreeForBackstagePassesAt5Days()
        {
            var item = GetBackstagePasses(sellIn: 5);
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(originalQuality + 3, item.Quality);
        }

        [TestMethod]
        public void IncreaseQualityByThreeForBackstagePassesAt1Day()
        {
            var item = GetBackstagePasses(sellIn: 1);
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(originalQuality + 3, item.Quality);
        }

        [TestMethod]
        public void DropQualityToZeroForBackstagePassesAt0Days()
        {
            var item = GetBackstagePasses(sellIn: 0);
            var originalQuality = item.Quality;

            ItemService.Update(item);

            Assert.AreEqual(0, item.Quality);
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

        private Item GetBackstagePasses(int sellIn = 10, int quality = 20)
        {
            return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
        }
    }
}