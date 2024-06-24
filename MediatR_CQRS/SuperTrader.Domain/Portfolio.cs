using SuperTrader.Core.Entities;

namespace SuperTrader.Domain
{
    public record Portfolio : BaseEntity<int>
    {
        public int UserId { get; init; }
        public int ShareId { get; init; }
        public decimal Quantity { get; init; }
        public virtual Share Share { get; init; }
        public virtual User User { get; init; }
    }
}
