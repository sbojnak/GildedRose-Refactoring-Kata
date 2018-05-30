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
                SelectUpdatorInstance(item).UpdateQuality(item);
            }
        }

        private Updator SelectUpdatorInstance(Item item)
        {
            if (ContainsSubstringIgnoreCase(item.Name, AgedBrie))
            {
                return new AgedBrieUpdator();
            }
            if (ContainsSubstringIgnoreCase(item.Name, BackstagePasses))
            {
                return new BackstagePassesUpdator();
            }
            if (ContainsSubstringIgnoreCase(item.Name, Sulfuras))
            {
                return new SulfurasUpdator();
            }
            return new Updator();
        }

        private bool ContainsSubstringIgnoreCase(string wholeString, string substring)
        {
            return wholeString.ToLower().Contains(substring);
        }
    }
}
