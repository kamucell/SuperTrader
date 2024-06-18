namespace SuperTrader.Core.Entities
{
    public sealed record Currency
    {
        public int Id { get; init;}
        public string  Sign { get; init; }
        public string Name { get; init; }

        public Money ToConvert(Money money,Currency currency)
        {
            return money;
        }
    }
}
