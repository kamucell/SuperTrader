using SuperTrader.Core.Entities;
namespace SuperTrader.Domain
{
    public record User : BaseEntity<int>
    {
        public string FullName { get; init; }
        public string Pwd { get; init; }
        public string Email { get; init; }
        public int UserType { get; init; }

        public virtual ICollection<Portfolio> Portfolios { get; init; }
        public virtual ICollection<ShareOwner> ShareOwners { get; init; }
        public virtual ICollection<Share> Shares { get; init; }
        public virtual ICollection<Transaction> Transactions { get; init; }
    }
}
