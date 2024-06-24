using SuperTrader.Core.Entities;

namespace SuperTrader.Domain
{
    public class Portfolio : BaseEntity<int>
    {

        public int UserId { get; set; }
        public int ShareId { get; set; }
        public decimal Quantity { get; set; }
        public virtual Share Share { get; set; }
        public virtual User User { get; set; }


    }
}
