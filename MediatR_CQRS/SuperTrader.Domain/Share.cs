using SuperTrader.Core.Entities;
using System;
using System.Collections.Generic;

namespace SuperTrader.Domain
{
    public record Share : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Quantity { get; set; }
        public decimal Sold { get; set; }
        public decimal Remain { get; set; }
        public int OwnerId { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<SharePriceDetail> SharePriceDetails { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual User Owner { get; set; }

    }
}
