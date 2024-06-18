using SuperTrader.Core.Entities;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class ShareOwner :BaseEntity<Int32>
    {
        public Int32 UserId { get; set; }
        public Int32 ShareId { get; set; }
        public String TotalQuantity { get; set; }
        public virtual User User { get; set; }


    }
}
