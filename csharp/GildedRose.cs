using System;
using System.Collections.Generic;
using System.Linq;
using csharp.QualityUpdators;

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
                    new AgedBrieUpdator().UpdateQuality(item);
                }

                else if (ContainsSubstringIgnoreCase(item.Name, BackstagePasses))
                {
                    new BackstagePassesUpdator().UpdateQuality(item);
                }
                else if (ContainsSubstringIgnoreCase(item.Name, Sulfuras))
                {
                    new SulfurasUpdator().UpdateQuality(item);
                }
                else
                {
                    new Updator().UpdateQuality(item);
                }
            }
        }

        private bool ContainsSubstringIgnoreCase(string wholeString, string substring)
        {
            return wholeString.ToLower().Contains(substring);
        }
    }
}
