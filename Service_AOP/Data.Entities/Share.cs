using SuperTrader.Core.Entities;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Share :BaseEntity<Int32>
    {
        public String Name { get; set; }
        public String Code { get; set; }
        public decimal Quantity { get; set; }
        public decimal Sold { get; set; }
        public decimal Remain { get; set; }
        public Int32 OwnerId { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<SharePriceDetail> SharePriceDetails { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual User Owner { get; set; }

    }
}
