using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateQuality_SingleItemOnZeroSellInAndZeroQuality_MaintainCorrectName()
        {
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 0}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual("foo", items[0].Name);
        }

        [Test]
        public void UpdateQuality_SingleItemOnSellInOne_DecreaseSellIn()
        {
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = 1}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].SellIn);
        }

        [Test]
        public void UpdateQuality_SingleItemOnSellInQualityOne_DecreaseQuality()
        {
            IList<Item> items = new List<Item> {new Item {Name = "foo", Quality = 1}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_SingleItemAfterConcert_QualityZero()
        {
            IList<Item> items =
                new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 40}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_SingleItemAfterAgedBrie_QualityNoMoreThan50()
        {
            IList<Item> items = new List<Item> {new Item {Name = "Aged Brie", Quality = 50}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_ThreeItemEachSpecificType_ReturnCorrectResults()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Aged Brie", Quality = 43, SellIn = -2},
                new Item {Name = "Backstage passes", Quality = 15, SellIn = 10},
                new Item {Name = "Sulfuras", Quality = 80, SellIn = 5}
            };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(45, items[0].Quality, "Quality of Aged Brie is not correct");
            Assert.AreEqual(-3, items[0].SellIn, "SellIn of Aged Brie is not correct");

            Assert.AreEqual(17, items[1].Quality, "Quality of Backstage passes is not correct");
            Assert.AreEqual(9, items[1].SellIn, "SellIn of Backstage passes is not correct");

            Assert.AreEqual(80, items[2].Quality, "Quality of Sulfuras is not correct");
            Assert.AreEqual(5, items[2].SellIn, "SellIn of Sulfuras is not correct");
        }

        [Test]
        public void UpdateQuality_SingleItemSellInBelowZero_QualityDecreaseTwice()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Random", Quality = 42, SellIn = -1} };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(40, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_SingleItemAgedBrieAfterSellInZero_QualityIncreaseTwice()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged brie", Quality = 45, SellIn = -1 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(47, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_SingleItemAgedBrieSellInZeroQuality49_QualityUnchanged()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged brie", Quality = 49, SellIn = -1 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(49, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_MultipleItemAllQualitiesZero_NoQualityBelowZero()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Aged Brie", Quality = 0, SellIn = -2},
                new Item {Name = "Abc bcdrg", Quality = 0, SellIn = 10},
                new Item {Name = "Random", Quality = 0, SellIn = 21}
            };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual(2, items[0].Quality, "Quality of Aged Brie is not correct");
            Assert.AreEqual(-3, items[0].SellIn, "SellIn of Aged Brie is not correct");

            Assert.AreEqual(0, items[1].Quality, "Quality of Backstage passes is not correct");
            Assert.AreEqual(9, items[1].SellIn, "SellIn of Backstage passes is not correct");

            Assert.AreEqual(0, items[2].Quality, "Quality of Sulfuras is not correct");
            Assert.AreEqual(20, items[2].SellIn, "SellIn of Sulfuras is not correct");
        }

        [Test]
        public void UpdateQuality_SingleItemAgedBrie_QualityIncreaseOnce()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged brie", Quality = 35, SellIn = 2 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(36, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_MultipleSulfuras_UnchangedValues()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Sulfuras", Quality = 80, SellIn = 15},
                new Item {Name = "Sulfuras", Quality = 80, SellIn = -4}
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual(80, items[0].Quality);
            Assert.AreEqual(15, items[0].SellIn);

            Assert.AreEqual(80, items[1].Quality);
            Assert.AreEqual(-4, items[1].SellIn);
        }
    }
}
