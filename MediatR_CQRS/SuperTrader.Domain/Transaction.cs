using System;
using SuperTrader.Core.Entities;
using SuperTrader.Domain.Structure;

namespace SuperTrader.Domain
{
    public record Transaction : BaseEntity<int>
    {
        public int UserId { get; init; }
        public int ShareId { get; init; }
        public EnumTransactionType TransactionType { get; init; }
        public decimal Sold { get; init; }
        public decimal Remain { get; init; }
        public decimal Price { get; init; }
        public DateTime TransactionDate { get; init; }
        public virtual Share? Share { get; init; }
        public virtual User? User { get; init; }
    }


}

