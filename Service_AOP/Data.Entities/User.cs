    using Data.Entities.Structure;
    using SuperTrader.Core.Entities;
    using System;
    using System.Collections.Generic;

    namespace Data.Entities
    {
        public  class User:BaseEntity<Int32>
        {
        public String FullName { get; set; }
        public String Pwd { get; set; }
        public String Email { get; set; }
        public Int32 UserType { get; set; }
        
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<ShareOwner> ShareOwners { get; set; }
        public virtual ICollection<Share> Shares { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }


    }
}
