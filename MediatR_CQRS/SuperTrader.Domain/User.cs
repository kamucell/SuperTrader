using SuperTrader.Core.Entities;
namespace SuperTrader.Domain
{
    public class User : BaseEntity<int>
    {
        public string FullName { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }

        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<ShareOwner> ShareOwners { get; set; }
        public virtual ICollection<Share> Shares { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }


    }
}
