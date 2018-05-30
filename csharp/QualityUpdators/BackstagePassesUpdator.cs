using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.QualityUpdators
{
    class BackstagePassesUpdator : Updator
    {
        public override void UpdateQuality(Item item)
        {
            item.Quality = QualityUpdateHelper.UpdateQualityWithCheck(item, i =>
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
    }
}
