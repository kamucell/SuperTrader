using System;
using Data.Entities.Structure;
using SuperTrader.Core.Entities;

namespace Data.Entities
{
    public class Transaction:BaseEntity<Int32>
    {
        public Int32 UserId { get; set; }
        public Int32 ShareId { get; set; }
        public EnumTransactionType TransactionType { get; set; }
        public Decimal Sold { get; set; }
        public Decimal Remain { get; set; }
        public Decimal Price { get; set; }
        public DateTime TransactionDate { get; set; }
        public virtual Share Share { get; set; }
        public virtual User User { get; set; }


    }
}
