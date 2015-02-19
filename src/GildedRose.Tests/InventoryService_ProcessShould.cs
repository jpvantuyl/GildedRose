using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class InventoryService_ProcessShould
    {
        [TestMethod]
        public void LowerSellInByOne()
        {
            var inventory = GetBoringInventory();
            var originalSellIn = inventory.GetSellIn();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalSellIn - 1, inventory.GetSellIn());
        }

        [TestMethod]
        public void LowerQualityByOne()
        {
            var inventory = GetBoringInventory();
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality - 1, inventory.GetQuality());
        }

        [TestMethod]
        public void LowerQualityByTwoWhenSellInIsZero()
        {
            var inventory = GetBoringInventory(sellIn: 0);
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality - 2, inventory.GetQuality());
        }

        [TestMethod]
        public void LowerSellInBelowZero()
        {
            var inventory = GetBoringInventory(sellIn: 0);

            InventoryService.Process(inventory);

            Assert.AreEqual(-1, inventory.GetSellIn());
        }

        [TestMethod]
        public void NotLowerQualityBelowZero()
        {
            var inventory = GetBoringInventory(quality: 0);

            InventoryService.Process(inventory);

            Assert.AreEqual(0, inventory.GetQuality());
        }

        [TestMethod]
        public void IncreaseQualityByOneForAgedBrie()
        {
            var inventory = GetAgedBrie();
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality + 1, inventory.GetQuality());
        }

        [TestMethod]
        public void IncreaseQualityByTwoForAgedBrieWhenExpired()
        {
            var inventory = GetAgedBrie(sellIn: 0);
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality + 2, inventory.GetQuality());
        }

        [TestMethod]
        public void NotIncreaseQualityAboveMax()
        {
            var inventory = GetAgedBrie(quality: Constants.MAX_QUALITY);

            InventoryService.Process(inventory);

            Assert.AreEqual(Constants.MAX_QUALITY, inventory.GetQuality());
        }

        [TestMethod]
        public void NotChangeQualityForLegendaryItem()
        {
            var inventory = GetLegendaryInventory();
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality, inventory.GetQuality());
        }

        [TestMethod]
        public void NotChangeSellInForLegendaryItem()
        {
            var inventory = GetLegendaryInventory();
            var originalSellIn = inventory.GetSellIn();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalSellIn, inventory.GetSellIn());
        }

        [TestMethod]
        public void IncreaseQualityByOneForBackstagePassesAt11Days()
        {
            var inventory = GetBackstagePasses(sellIn: 11);
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality + 1, inventory.GetQuality());
        }

        [TestMethod]
        public void IncreaseQualityByTwoForBackstagePassesAt10Days()
        {
            var inventory = GetBackstagePasses(sellIn: 10);
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality + 2, inventory.GetQuality());
        }

        [TestMethod]
        public void IncreaseQualityByTwoForBackstagePassesAt6Days()
        {
            var inventory = GetBackstagePasses(sellIn: 6);
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality + 2, inventory.GetQuality());
        }

        [TestMethod]
        public void IncreaseQualityByThreeForBackstagePassesAt5Days()
        {
            var inventory = GetBackstagePasses(sellIn: 5);
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality + 3, inventory.GetQuality());
        }

        [TestMethod]
        public void IncreaseQualityByThreeForBackstagePassesAt1Day()
        {
            var inventory = GetBackstagePasses(sellIn: 1);
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality + 3, inventory.GetQuality());
        }

        [TestMethod]
        public void DropQualityToZeroForBackstagePassesAt0Days()
        {
            var inventory = GetBackstagePasses(sellIn: 0);
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(0, inventory.GetQuality());
        }

        [TestMethod]
        public void LowerQualityByTwoForConjuredItems()
        {
            var inventory = GetConjuredManaCake();
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality - 2, inventory.GetQuality());
        }

        [TestMethod]
        public void LowerQualityByFourForConjuredItemsAfterSellByDate()
        {
            var inventory = GetConjuredManaCake(sellIn: 0);
            var originalQuality = inventory.GetQuality();

            InventoryService.Process(inventory);

            Assert.AreEqual(originalQuality - 4, inventory.GetQuality());
        }


        private IInventory GetBoringInventory(int sellIn = 10, int quality = 20)
        {
            return InventoryFactory.Create(new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality });
        }

        private IInventory GetAgedBrie(int sellIn = 10, int quality = 20)
        {
            return InventoryFactory.Create(new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality });
        }

        private IInventory GetLegendaryInventory()
        {
            return InventoryFactory.Create(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
        }

        private IInventory GetBackstagePasses(int sellIn = 10, int quality = 20)
        {
            return InventoryFactory.Create(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality });
        }

        private IInventory GetConjuredManaCake(int sellIn = 10, int quality = 20)
        {
            return InventoryFactory.Create(new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality });
        }
    }
}