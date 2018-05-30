using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Helpers;

namespace csharp.QualityUpdators
{
    class Updator
    {
        public virtual void UpdateQuality(Item item)
        {
            item.Quality = QualityUpdateHelper.UpdateQualityWithCheck(item, i => i - 1);
            item.SellIn--;
        }
    }
}
