namespace SuperTrader.Core.Entities
{
    public sealed  record Money
    {
        public decimal Value{ get; init; }
        public Currency Currency { get; init; }

    }
}
