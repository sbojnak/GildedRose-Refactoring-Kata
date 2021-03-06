﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.QualityUpdators
{
    class AgedBrieUpdator : Updator
    {
        public override void UpdateQuality(Item item)
        {
            item.Quality = QualityUpdateHelper.UpdateQualityWithCheck(item, i => i + 1);
            item.SellIn--;
        }
    }
}
