using System.Collections.Generic;

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

                if (!ContainsSubstringIgnoreCase(item.Name, AgedBrie) && !ContainsSubstringIgnoreCase(item.Name, BackstagePasses) && item.Quality > 0 && !ContainsSubstringIgnoreCase(item.Name, Sulfuras))
                {
                    item.Quality = item.Quality - 1;
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (ContainsSubstringIgnoreCase(item.Name, BackstagePasses))
                        {
                            if (item.SellIn < 11 && item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                            if (item.SellIn < 6 && item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }

                if (!ContainsSubstringIgnoreCase(item.Name, Sulfuras))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!ContainsSubstringIgnoreCase(item.Name, AgedBrie))
                    {
                        if (!ContainsSubstringIgnoreCase(item.Name, BackstagePasses))
                        {
                            if (item.Quality > 0 && !ContainsSubstringIgnoreCase(item.Name, Sulfuras))
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        private bool ContainsSubstringIgnoreCase(string wholeString, string substring)
        {
            return wholeString.ToLower().Contains(substring);
        }
    }
}
