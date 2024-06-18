using SuperTrader.Core.Entities;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class SharePriceDetail :BaseEntity<Int32>
    {
        
        public Int32 ShareId { get; set; }
        public DateTime Date { get; set; }

        public decimal Price { get; set; }
        
        public virtual Share Share { get; set; }

    }
}
