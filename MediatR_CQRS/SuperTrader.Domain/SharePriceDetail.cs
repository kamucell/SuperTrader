using SuperTrader.Core.Entities;
using System;
using System.Collections.Generic;

namespace SuperTrader.Domain
{
    public record SharePriceDetail : BaseEntity<int>
    {

        public int ShareId { get; set; }
        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public virtual Share Share { get; set; }

    }
}
