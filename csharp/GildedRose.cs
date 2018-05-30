using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public class GildedRose
    {
        private const string Sulfuras = "sulfuras";
        private const string AgedBrie = "aged brie";
        private const string BackstagePasses = "backstage passes";

        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                if (ContainsSubstringIgnoreCase(item.Name, AgedBrie))
                {
                    item.Quality = UpdateQualityWithCheck(item, i => i + 1);
                    item.SellIn--;
                }

                else if (ContainsSubstringIgnoreCase(item.Name, BackstagePasses))
                {
                    item.Quality = UpdateQualityWithCheck(item, i =>
                    {
                        if (item.SellIn <= 0)
                        {
                            return 0;
                        }
                        if (item.SellIn < 6)
                        {
                            return i + 3;
                        }
                        if (item.SellIn < 11)
                        {
                            return i + 2;
                        }
                        return i + 1;
                    });
                    item.SellIn--;
                }
                else if (!ContainsSubstringIgnoreCase(item.Name, Sulfuras))
                {
                    item.Quality = UpdateQualityWithCheck(item, i => i - 1);
                    item.SellIn--;
                }
            }
        }

        private int UpdateQualityWithCheck(Item item, Func<int, int> qualityUpdater)
        {
            int updatedQuality = qualityUpdater(item.Quality);
            if (item.SellIn < 0)
            {
                updatedQuality = qualityUpdater(updatedQuality);
            }
            return Enumerable.Range(0, 50).Contains(updatedQuality) ? updatedQuality : item.Quality;
        }

        private bool ContainsSubstringIgnoreCase(string wholeString, string substring)
        {
            return wholeString.ToLower().Contains(substring);
        }
    }
}
