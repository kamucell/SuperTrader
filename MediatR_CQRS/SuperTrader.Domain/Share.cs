using SuperTrader.Core.Entities;
using SuperTrader.Core.Exception;
using System;
using System.Collections.Generic;

namespace SuperTrader.Domain
{
    public record Share : BaseEntity<int>
    {
        public Share()
        {

        }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Sold { get; private set; }
        public decimal Remain { get; private set; }
        public int OwnerId { get; private set; }
        public virtual ICollection<Portfolio> Portfolios { get; private set; }
        public virtual ICollection<SharePriceDetail> SharePriceDetails { get; private set; }
        public virtual ICollection<Transaction> Transactions { get; private set; }
        public virtual User Owner { get; private set; }

        public void NewShare(string name, string code, decimal quantity, int ownerId)
        {
            if (code.Length != 3 || !code.All(char.IsUpper)) throw new RuleException("CodeHaveToBe3andUpperLetters");
            
            if (quantity <= 0) throw new RuleException("QuantityHaveToBeGreaterThanZero");
            if (ownerId < 0)    throw new RuleException("OwnerIdHaveToBeAssigned");

            Name = name;
            Code = code;
            Quantity = quantity;
            OwnerId = ownerId;
        }
    }
}
