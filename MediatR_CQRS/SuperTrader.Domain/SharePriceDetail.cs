using SuperTrader.Core.Entities;
using System;
using System.Collections.Generic;

namespace SuperTrader.Domain
{
    public record SharePriceDetail : BaseEntity<int>
    {

        public int ShareId { get; init; }
        public DateTime Date { get; init; }

        public decimal Price { get; init; }

        public virtual Share Share { get; init; }

    }
}
