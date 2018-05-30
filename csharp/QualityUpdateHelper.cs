using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    static class QualityUpdateHelper
    {
        public static int UpdateQualityWithCheck(Item item, Func<int, int> qualityUpdater)
        {
            int updatedQuality = qualityUpdater(item.Quality);
            if (item.SellIn < 0)
            {
                updatedQuality = qualityUpdater(updatedQuality);
            }
            return Enumerable.Range(0, 50).Contains(updatedQuality) ? updatedQuality : item.Quality;
        }
    }
}
