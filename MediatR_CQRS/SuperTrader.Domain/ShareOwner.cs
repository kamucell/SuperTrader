using SuperTrader.Core.Entities;
using System;
using System.Collections.Generic;

namespace SuperTrader.Domain
{
    public record ShareOwner : BaseEntity<int>
    {
        public int UserId { get; init; }
        public int ShareId { get; init; }
        public string TotalQuantity { get; init; }
        public virtual User User { get; init; }


    }
}
