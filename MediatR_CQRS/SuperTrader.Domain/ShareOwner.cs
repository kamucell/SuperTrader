using SuperTrader.Core.Entities;
using System;
using System.Collections.Generic;

namespace SuperTrader.Domain
{
    public class ShareOwner : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int ShareId { get; set; }
        public string TotalQuantity { get; set; }
        public virtual User User { get; set; }


    }
}
