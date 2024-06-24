using System;
using SuperTrader.Core.Entities;
using SuperTrader.Domain.Structure;

namespace SuperTrader.Domain
{
    public record Transaction : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int ShareId { get; set; }
        public EnumTransactionType TransactionType { get; set; }
        public decimal Sold { get; set; }
        public decimal Remain { get; set; }
        public decimal Price { get; set; }
        public DateTime TransactionDate { get; set; }
        public virtual Share Share { get; set; }
        public virtual User User { get; set; }


    }
}
