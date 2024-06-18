using SuperTrader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Portfolio:BaseEntity<Int32>
    {
        
        public Int32 UserId { get; set; }
        public Int32 ShareId { get; set; }
        public Decimal Quantity { get; set; }
        public virtual Share Share { get; set; }
        public virtual User User { get; set; }


    }
}
