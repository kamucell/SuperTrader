using SuperTrader.Core.DataAccess.EFRepository;

namespace Data.Repository
{
    public class RpUser : EfEntityRepositoryBase<SuperTrader.Domain.User, SuperTraderContext>, Abstract.IRpUser
    {
        public RpUser() : base()
        {
        }
        
    }
}
