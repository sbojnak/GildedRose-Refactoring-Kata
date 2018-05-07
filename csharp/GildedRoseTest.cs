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
        public void UpdateQuality_SingleItemOnSellInOne_DecreaseQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}
