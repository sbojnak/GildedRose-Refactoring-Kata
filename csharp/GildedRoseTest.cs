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
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void UpdateQuality_SingleItemOnSellInOne_DecreaseSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].SellIn);
        }

        [Test]
        public void UpdateQuality_SingleItemOnSellInQualityOne_DecreaseQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void UpdateQuality_SingleItemAfterConcert_QualityZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 40 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void UpdateQuality_SingleItemAfterAgedBrie_QualityNoMoreThan50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void UpdateQuality_ThreeItemEachSpecificType_ReturnCorrectResults()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Aged Brie", Quality = 43, SellIn = -2},
                new Item { Name = "Backstage passes", Quality = 15, SellIn = 10},
                new Item { Name = "Sulfuras", Quality = 80, SellIn = 5}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(45, Items[0].Quality, "Quality of Aged Brie is not correct");
            Assert.AreEqual(-3, Items[0].SellIn, "SellIn of Aged Brie is not correct");

            Assert.AreEqual(17, Items[1].Quality, "Quality of Backstage passes is not correct");
            Assert.AreEqual(9, Items[1].SellIn, "SellIn of Backstage passes is not correct");

            Assert.AreEqual(80, Items[2].Quality, "Quality of Sulfuras is not correct");
            Assert.AreEqual(5, Items[2].SellIn, "SellIn of Sulfuras is not correct");
        }
    }
}
